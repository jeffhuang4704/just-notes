# just-notes

## TODO
👉 🆗 delve debug related   
👉 🆗 opa/rego related   
👉 cosign/sigstore related   
👉 OpenTelemetry   
👉 🆗 ssh tunnel to access remote NAT behind service  
👉 consul usage     
👉 jq cheatsheet   
👉 vim cheatsheet   
👉 GCP usage (how to start a VM, etc)   
👉 saml/oidc related, setup keycloak and usage   
👉 ldap related   
👉 tools usage `cosign`, `crane`   
👉 container tool `cdebug`  
👉 how to mirror registry?   
👉 k8s cert manager
- Misc
    - [Install NeuVector steps, start from scratch](onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#*%20K8s%20installation&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={4199C511-0482-4B87-A93D-6DD3BC4F143F}&end)
    - [k8s user and permissions](onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#RBAC%20-%20User%20%20Permissions&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={82499009-2B87-4C45-89A7-815E06FA123F}&end)
    - [Create a Kubernetes TLS Ingress from scratch in Minikube](https://www.youtube.com/watch?v=7K0gAYmWWho&ab_channel=kubucation)
        - [Notes](onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#2022-04%20Part-1&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={CC7EAB50-073E-4F1A-B813-93A92C95A974}&object-id={2FF45C4A-DABC-44B5-B759-E11625C64FCD}&23)
    - [Purchased domain, gotalentpool.com, try to apply in my env](onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#2022-04%20Part-1&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={CC7EAB50-073E-4F1A-B813-93A92C95A974}&object-id={7E7F2D08-1FB9-4C77-984F-2C3ADB680E07}&DB)
    - How to generate certificate, so it can be used in testing web server, or admission control,,, check the book "Microservices Security in Action", the appendix G
- Rancher
    - how to install
    - [Run Rancher in a docker](onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#2022-04%20Part-2&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={F75B72AC-6A3C-414D-8D0D-CB04851BC87F}&object-id={D55210C5-2B86-4A41-A6D5-E81C52942D54}&C)
    - install NeuVector and integrate with Rancher
    - there is a book related to Rancher
- NeuVector related,  
    - install manually with backup restore..
        - check this [How to restore, OneNote Work > Notes01](onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#Debug%20Controller%20(1)&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={65EA81B0-687C-4BB6-8710-AD46241F20B9}&end)
    - install by helm
    - enable debug, disable enforcer, use PVC to store config, et  
    - how to debug controller
        - view log
        - copy private build into controller and replace it
            - add environment variables..
        - add `nodePort` service for controller so we can call rest directly easier
    - how to do private build of controller container image and publish to docker
    - restore from backup..  
    - build script   
    - grpc build script   
    - when add a new grpc, what's the step
    - federation
        - how to setup
        - how it works
    

## 2023
- [k8s admission control debugging](./2023/k8s-admission-control-debug.md)
- [SSH Tunnel, connect to host behind NAT](./2023/ssh-tunnel.md)   
- [NeuVector Onboarding and Best Practices Guide](./documents/_GOOD_NV_Onboarding_5.0.pdf)   
- Delve [Delve tips](./2023/delve-debugging.md)   
    - debug flags 
    - remove `-trimpath` when debug open source project
    - pass parameter to CLI
    - debug program running in k8s container
- [observe cosign traffic](./2023/cosign-traffic.md)
- [nice golang resources](./2023/golang-part1.md)
- [how to use minikube, install neuvector and debug](./2023/minikube-howto.md)
- [opa rego](./2023/opa-rego.md)
- [opa rego, sort arry object by key](./2023/opa-rego-sort-by-array-object.md)
- [private registry usage](./2023/private-registry.md)
- [create servcie accont and use in kubeconfig](./2023/serviceaccount-kubeconfig.md)


## 2021
- C# ADO.NET sample code
- C# dependency injection in console program

## 2020
- 