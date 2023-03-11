# k8s admission control debugging

## tips

- if we found overall admission webhook seems not working, we can observe the `kube-apiserver` log   
- use `kubectl get pods -n kube-system` to see the `kube-apiserver` pod name   
- use `kubectl logs -f kube-apiserver-xxx -n kube-system` to see log    
- in neuvector controller, remember to place the correct `keys.go` file for admission control to work properly   

## some notes

[note](../documents/admission_control_debug.pdf)