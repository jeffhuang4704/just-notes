# just-notes

## To study
- Articles
- Audiobook
    - audiobook - the 5-minute interview
    - audiobook - how the future works
- Books 
    - Kubernetes Patterns
    - GitOps and Kubernetes
    - Core Kubernetes
    - Microservices Security in Action
- Videos
    - [It’s Complicated: Relationships Between Objects In OCI Registries](https://www.youtube.com/watch?v=VZckJNkJ0nQ&ab_channel=CNCF%5BCloudNativeComputingFoundation%5D)
    - [Life of a Sigstore Signature](https://www.youtube.com/watch?v=DrHrkSsozB0&list=PLj6h78yzYM2MUNId2hvHBnrGCCbmou_gl&index=48&ab_channel=CNCF%5BCloudNativeComputingFoundation%5D)

    - [How To Learn Something New? - Game Devlog #1](https://www.youtube.com/watch?v=LTlBElDPDDM&ab_channel=LiveOverflow)
    - [Understanding user namespaces - Michael Kerrisk](https://www.youtube.com/watch?v=83NOk8pmHi8&ab_channel=foss-north)
    - [Cgroups, namespaces, and beyond: what are containers made from?](https://www.youtube.com/watch?v=sK5i-N34im8&t=148s&ab_channel=Docker)
    - [This Is How Docker Works, The Fun Way!](https://www.youtube.com/watch?v=-NzfOhSAZpA&ab_channel=CodingTech)

## TODO
👉 🆗 delve debug related   
👉 🆗 opa/rego related   
👉 OpenTelemetry   
👉 🆗 ssh tunnel to access remote NAT behind service  
👉 consul usage     
👉 jq cheatsheet   
👉 vim cheatsheet   
👉 GCP usage (how to start a VM, etc)   
👉 saml/oidc related, setup keycloak and usage   
👉 ldap related   
👉 GitHub action  
👉 how to mirror registry?    
👉 k8s cert manager   
- Misc
    - [CFSSL CloudFlare's PKI/TLS toolkit](https://github.com/cloudflare/cfssl)
        - [Use CFSSL to generate certificates](https://github.com/marcel-dempers/docker-development-youtube-series/blob/master/kubernetes/admissioncontrollers/introduction/tls/ssl_generate_self_signed.md)
    - [Install NeuVector steps, start from scratch]
        - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#*%20K8s%20installation&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={4199C511-0482-4B87-A93D-6DD3BC4F143F}&end`
    - [k8s user and permissions]
        - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#RBAC%20-%20User%20%20Permissions&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={82499009-2B87-4C45-89A7-815E06FA123F}&end`
    - [Create a Kubernetes TLS Ingress from scratch in Minikube](https://www.youtube.com/watch?v=7K0gAYmWWho&ab_channel=kubucation)
        - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#2022-04%20Part-1&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={CC7EAB50-073E-4F1A-B813-93A92C95A974}&object-id={2FF45C4A-DABC-44B5-B759-E11625C64FCD}&23`
    - [Purchased domain, gotalentpool.com, try to apply in my env]
        - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#2022-04%20Part-1&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={CC7EAB50-073E-4F1A-B813-93A92C95A974}&object-id={7E7F2D08-1FB9-4C77-984F-2C3ADB680E07}&DB`
    - How to generate certificate, so it can be used in testing web server, or admission control,,, check the book "Microservices Security in Action", the appendix G
    - [很好的練習, use simple scripts to call k8s apis]
        - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#2022-05%20Part%20-5&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={6C311090-AC10-4EF5-A4A0-A2E7350723FF}&object-id={4786CD3D-0FF2-477B-92F3-078EEE5381CF}&B`
    - [generate cert in Makefile](https://github.com/kubernetes/pod-security-admission/tree/master/webhook)

## Container
- [Containers series](https://www.youtube.com/playlist?list=PLawsLZMfND4nz-WDBZIj8-nbzGFD4S9oz)
- [containerd - a secret hero of the Cloud Native world](https://www.youtube.com/watch?v=3_jUWW2j_TI&ab_channel=CloudNativeIslamabad)

## Kubernetes
- [Deploying Stateful Applications in Kubernetes](https://app.pluralsight.com/library/courses/kubernetes-deploying-stateful-applications/table-of-contents)
- [Managing Ingress Traffic Patterns for Kubernetes Services](https://app.pluralsight.com/library/courses/managing-ingress-traffic-patterns-kubernetes-services/table-of-contents)
- [k8s admission control debugging](./2023/k8s-admission-control-debug.md)
- [create servcie accont and use in kubeconfig](./2023/serviceaccount-kubeconfig.md)

## Kubernetes development
- Admission Control
    - some notes (part 1).. `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#Admission%20Webhook&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={D237EEAA-0F32-42B9-B895-E19E89C17E5C}&end`
    - some notes (part 2).. `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#Webhook%20steps&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={311709A4-3EA4-4ED2-AA92-E9FF1E419EBA}&end`
    - notes part 3 `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work2\Notes-01.one#Admission%20Control%20(1)&section-id={52646D5D-AE0F-4403-A1FE-FB6BA9C4E501}&page-id={821A322D-D18D-4AB7-B7A7-236A0326917E}&end`
    - [How to build a Kubernetes Webhook | Admission controllers](https://www.youtube.com/watch?v=1mNYSn2KMZk&ab_channel=ThatDevOpsGuy)
    - [derived from previous item, my sample,,, in the tools repo - C:\MyProjects\tools\admissioncontrollers-opa-server-v3a]
    - [article](https://github.com/elithrar/admission-control#configuring-a-server)
    - [example](https://docs.giantswarm.io/advanced/custom-admission-controller/)
    - [TLS certificate notes for Webhook](https://github.com/marcel-dempers/docker-development-youtube-series/blob/master/kubernetes/admissioncontrollers/introduction/README.md)

## React
- [React 17: Getting Started](https://app.pluralsight.com/library/courses/react-js-getting-started/table-of-contents)

## Rancher
- how to install
- [Run Rancher in a docker]
    - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#2022-04%20Part-2&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={F75B72AC-6A3C-414D-8D0D-CB04851BC87F}&object-id={D55210C5-2B86-4A41-A6D5-E81C52942D54}&C`
- install NeuVector and integrate with Rancher
- there is a book related to Rancher

## Tools
- `cosign`, `crane`  
- `podman`, there is a book called `Podman for DevOps` 
- container tool `cdebug`  

## Sigstore, Cosign
- use GitHub Action to sign the image... I have done something..
- [observe cosign traffic](./2023/cosign-traffic.md)

## OPA/Rego
- [Rego Debugging Tool](https://github.com/fugue/fregot)
- [opa rego](./2023/opa-rego.md)
- [opa rego, sort arry object by key](./2023/opa-rego-sort-by-array-object.md)
- OPA print function (nice debug mechanism) `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-02.one#2022-07%20Part%20-2&section-id={955E51B5-E20C-4DED-8FB6-5D34F6115376}&page-id={B3BA7FF6-79B0-473C-95EA-4576EF17F33B}&object-id={9A28311D-C346-4431-A976-D09ED4D85875}&B`

## 2023
- [SSH Tunnel, connect to host behind NAT](./2023/ssh-tunnel.md)   
- [private registry usage](./2023/private-registry.md)

## NeuVector
- [NeuVector Onboarding and Best Practices Guide](./documents/_GOOD_NV_Onboarding_5.0.pdf)   
- [how to use minikube, install neuvector and debug](./2023/minikube-howto.md)
- NeuVector related,  
    - install manually with backup restore..
        - check this [How to restore, OneNote Work > Notes01]
            - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#Debug%20Controller%20(1)&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={65EA81B0-687C-4BB6-8710-AD46241F20B9}&end`
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
        - notes - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work2\Notes-01.one#Federation,%20KV%20Store%20Sync&section-id={52646D5D-AE0F-4403-A1FE-FB6BA9C4E501}&page-id={26B3B10C-CE3E-4EE9-9990-5DF51FFF525E}&end`

## Golang
- [nice golang resources](./2023/golang-part1.md)
- [Go maps in action](https://go.dev/blog/maps)
- [Go Concurrency Guide](https://github.com/luk4z7/go-concurrency-guide)
- 👍 [Uber - Dynamic Data Race Detection in Go Code](https://www.uber.com/blog/dynamic-data-race-detection-in-go-code/)
- 👍 [Uber - Data Race Patterns in Go](https://www.uber.com/blog/data-race-patterns-in-go/)
- [Common Anti-Patterns in Go Web Applications](https://threedots.tech/post/common-anti-patterns-in-go-web-applications/)
- [gRPC video tutorail series](https://www.youtube.com/playlist?list=PLmD8u-IFdreyyTx93jJ5GkijwDXFqyr3T)   
- [Concurrent Programming in Go](https://app.pluralsight.com/library/courses/go-programming-concurrent/table-of-contents)
- [GopherCon 2020: Jonathan Amsterdam - Working with Errors](https://www.youtube.com/watch?v=IKoSsJFdRtI&list=PL2ntRZ1ySWBfUint2hCE1JRxRWChloasB&index=47&t=9s&ab_channel=GopherAcademy)

## Golang Debugging - Delve
- Delve [Delve tips](./2023/delve-debugging.md)   
    - debug flags 
    - remove `-trimpath` when debug open source project
    - pass parameter to CLI
    - debug program running in k8s container

## C#
- C# ADO.NET sample code
- C# dependency injection in console program

