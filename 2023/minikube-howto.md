## minikube 

### Notes
- notes 1 (mount volume, ssh tunnel, load balancing)
  - Deploying Stateful Applications in Kubernetes (has a nfs server, minikube volume example)
  - minikube example, deployment and expose service
  - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work5\Notes-1.one#minikube&section-id={2F66D987-20DB-432B-95D1-0351E2341ECC}&page-id={6628C918-8152-4C7A-B005-04918D5EBF27}&end`


### on an Ubuntu box
```
install docker, https://docs.docker.com/engine/install/ubuntu/
docker post-installation, https://docs.docker.com/engine/install/linux-postinstall/

install latest golang, https://go.dev/doc/install
install latest delve, https://github.com/go-delve/delve
        # Install the latest release:
        $ go install github.com/go-delve/delve/cmd/dlv@latest

install minikube, https://minikube.sigs.k8s.io/docs/start/
install kubectl, https://kubernetes.io/docs/tasks/tools/install-kubectl-linux/

install jq
```

### start/stop/delete minikube,
```
minikube start --memory 6144 --cpus 2

minikube stop
minikube delete
```

### install NeuVector (use docker part yaml)
```
https://open-docs.neuvector.com/deploying/kubernetes
```

### modify the controller deployment to enable debug log
```
kubectl edit deployment neuvector-controller-pod -n neuvector
add environment
- name: CTRL_PATH_DEBUG
    value: "true"
```

### modify the encofer daemonset to disable self protection (we need to overwrite controller binary)
```
kubectl edit daemonset neuvector-enforcer-pod -n neuvector
add environment
- name: ENFORCER_SKIP_NV_PROTECT
value: "1"
```

### add a service for controller REST API, so we can use curl directly
```
neuvector@ubuntu2204d:~$ cat controller_nodeport.yaml
apiVersion: v1
kind: Service
metadata:
  name: neuvector-service-controller-debug
  namespace: neuvector
spec:
  ports:
    - port: 10443
      name: controller
      protocol: TCP
  type: NodePort
  selector:
    app: neuvector-controller-pod


neuvector@ubuntu2204d:~$ kubectl get svc -n neuvector
NAME                                 TYPE        CLUSTER-IP       EXTERNAL-IP   PORT(S)                         AGE
neuvector-service-controller-debug   NodePort    10.100.233.196   <none>        10443:32539/TCP                 27h
```

### add environment varible on the Ubuntu box, edit ~/.bashrc
```
## neuvector controller debug
export K8sNodeIP=192.168.49.2    # this can be get via [minikube ip]
export ControllerSvcPORT=32539   # this is the service we just added in previous step

   we can then use curl to call REST api directly

neuvector@ubuntu2204d:~/rest_api$ cat get_admissionOptions.sh
TOKEN=$( curl --silent -k -H "Content-Type: application/json" -d '{"password": {"username": "admin", "password": "admin"}}' "https://$K8sNodeIP:$ControllerSvcPORT/v1/auth" | jq -r '.token.token')
curl -k -H "Content-Type: application/json" -H "X-Auth-Token: $TOKEN" "https://$K8sNodeIP:$ControllerSvcPORT/v1/admission/options"
```

### modify the neuvector-service-webui service, change its type from LoadBalancer to NodePort
```
kubectl edit svc neuvector-service-webui -n neuvector

and get it's port 3xxxx (this case is 30869)

    neuvector@ubuntu2204d:~$ kubectl get svc -n neuvector
    NAME                                 TYPE        CLUSTER-IP       EXTERNAL-IP   PORT(S)
    neuvector-service-controller-debug   NodePort    10.100.233.196   <none>        10443:32539/TCP
    neuvector-service-webui              NodePort    10.100.197.50    <none>        8443:30869/TCP
```

### SSH Proxy Tunnel
```
   on local machine (the one you want to use browser to connect to NeuVector UI, like windows machine), start ssh proxy tunnel:
   ssh -N -L localhost:8888:192.168.49.2:30869 neuvector@10.1.45.43

        [localhost:8888] is the address we visit on local Windows browser
        [192.168.49.2:30869] is neuvector web UI, 92.168.49.2 is the minikube ip, 30869 is the webui svc port
        [neuvector@10.1.45.43]  is the ssh login account on the Ubuntu which host minikube
   then start browser, and visit [https://localhost:8888], then the NeuVector UI should show up.
```

### SSH setting (easy access without password)
```
   we can login to ssh without typing password everytime.
   On windows machine (client), generate a key via
   ssh-keygen -t rsa

   you will now have ~/.ssh/id_rsa.pub   (public key)
        C:\Users\Chih-JenHuang\.ssh> dir .\id_rsa.pub

   we need to add this public key to the target server (for example, the ubuntu box)
   echo '...public key...' >> ~/.ssh/authorized_keys
```

### Delve Debug
```
[x] need to replace the controller binary without optimization,
jeff@SUSE-387793:~/go/src/github.com/neuvector/neuvector/controller$ cat Makefile
all:
        # go build --ldflags '-extldflags "-static"'
        # go build -ldflags='-s -w'     # release build
        go build -gcflags=all="-N -l"   # debug build

[x] build the debug binary and copy to the Ubuntu box
jeff@SUSE-387793:~/go/src/github.com/neuvector/neuvector/controller$ cat cp2lab_e.sh
scp controller neuvector@10.1.45.44:~/debug/controller

echo "done.."
echo "goes to lab_E (10.1.45.44) and execute the ~/debug/deployController.sh"

[x] after we have the debug controller, replace it with the one currently running
~/debug/deployController.sh

[x] on the Ubuntu box, start delve server
neuvector@ubuntu2204d:~$ cat dlv_server.sh
#! /usr/bin/bash

CONTROLLER_PID=`pidof controller`
sudo /home/neuvector/go/bin/dlv attach ${CONTROLLER_PID} --headless --accept-multiclient --only-same-user=false --listen=:12345

[x] on the build environment (has the source code), connect to the server,
        dlv connect 10.1.45.43:12345
```