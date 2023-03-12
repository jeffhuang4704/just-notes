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

## Table usage..
| Command | Description |
| --- | --- |
| git status | List all new or modified files |
| git diff | Show file differences that haven't been staged |

## TODO
👉 consul usage     
👉 jq cheatsheet   
👉 GCP usage (how to start a VM, etc)   
👉 ldap related   
👉 GitHub action  
👉 how to mirror registry?    
👉 k8s cert manager   
- 👉👉 use lint to check neuvector code (consider to use golang 1.19 to compile it?)
    - [How Static Code Analysis Prevents You From Waking Up at 3AM With Production on Fire](https://www.youtube.com/watch?v=cVUrScvthqs&ab_channel=Cadey)
    - [go vet](https://pkg.go.dev/cmd/vet)
    - [staticcheck](https://staticcheck.io/)

## OpenTelemetry
- notes 1 - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work5\Notes-1.one#OpenTelemetry&section-id={2F66D987-20DB-432B-95D1-0351E2341ECC}&page-id={77BF0BDB-0FD3-4DBB-9001-A70BB7615D3C}&end3`

## Container
- [YouTube - Containers series](https://www.youtube.com/playlist?list=PLawsLZMfND4nz-WDBZIj8-nbzGFD4S9oz)
- [YouTube - containerd - a secret hero of the Cloud Native world](https://www.youtube.com/watch?v=3_jUWW2j_TI&ab_channel=CloudNativeIslamabad)

## Kubernetes
- [Plusalsight - Deploying Stateful Applications in Kubernetes](https://app.pluralsight.com/library/courses/kubernetes-deploying-stateful-applications/table-of-contents)
- [Plusalsight - Managing Ingress Traffic Patterns for Kubernetes Services](https://app.pluralsight.com/library/courses/managing-ingress-traffic-patterns-kubernetes-services/table-of-contents)
- [k8s admission control debugging](./2023/k8s-admission-control-debug.md)
- [create servcie accont and use in kubeconfig](./2023/serviceaccount-kubeconfig.md)
- [Create a Kubernetes TLS Ingress from scratch in Minikube](https://www.youtube.com/watch?v=7K0gAYmWWho&ab_channel=kubucation)
    - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#2022-04%20Part-1&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={CC7EAB50-073E-4F1A-B813-93A92C95A974}&object-id={2FF45C4A-DABC-44B5-B759-E11625C64FCD}&23`
- [k8s user and permissions]
    - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#RBAC%20-%20User%20%20Permissions&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={82499009-2B87-4C45-89A7-815E06FA123F}&end`
- [很好的練習, use simple scripts to call k8s apis]
    - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#2022-05%20Part%20-5&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={6C311090-AC10-4EF5-A4A0-A2E7350723FF}&object-id={4786CD3D-0FF2-477B-92F3-078EEE5381CF}&B`


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
- client-go programming
    - [client-go-example by Ivan Velichko](https://github.com/iximiuz/client-go-examples)
    - notes 1 - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work4\Notes-1.one#client-go%20part%201&section-id={1D02D4D6-56CA-42D6-8318-F2060FC425CD}&page-id={53CFB322-523F-4576-B81E-6BE3505318B8}&end`
    - notes 2 - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work4\Notes-1.one#client-go%20part%202&section-id={1D02D4D6-56CA-42D6-8318-F2060FC425CD}&page-id={BEE6C30E-C0DB-4615-9722-0AE69784793D}&end`
- CRD
    - [Check videos from Vivek Singh](https://www.youtube.com/@viveksinghggits)
    - notes 1 - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work4\Notes-1.one#K8s%20CRD&section-id={1D02D4D6-56CA-42D6-8318-F2060FC425CD}&page-id={BC4AC015-2F05-46BC-9790-05EBD00A1075}&end`

## CKA
- Notes 1 - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work4\Notes-1.one#CKA&section-id={1D02D4D6-56CA-42D6-8318-F2060FC425CD}&page-id={F29858C3-B14B-4CE1-A144-E4A20AC27542}&end`
- list the tech nana's course...

## SAML/OIDC
- notes 1(keycloak) - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work4\Notes-1.one#2022-12%20Part%20-6%20(keycloak,%20oidc)&section-id={1D02D4D6-56CA-42D6-8318-F2060FC425CD}&page-id={B204B466-8DB7-4BFE-A5BB-D67DBDA9A2E8}&end`
- notes 2 (keycloak, okta) - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work4\SAML_OIDC.one#Keycloak,%20okta%20config%20-%202022/12/28%20issue&section-id={EA6E4285-15ED-4D36-9E4B-A02E0D83C157}&page-id={6142F371-4F96-4DE8-9605-AC5F32C82943}&end`

## Rancher
- how to install
- [Run Rancher in a docker]
    - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#2022-04%20Part-2&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={F75B72AC-6A3C-414D-8D0D-CB04851BC87F}&object-id={D55210C5-2B86-4A41-A6D5-E81C52942D54}&C`
- install NeuVector and integrate with Rancher
- there is a book related to `Rancher Deep Dive`

## Tools
- `cosign`, `crane`  
- `podman`, there is a book called `Podman for DevOps` 
- container tool `cdebug`  
- OAuth2c: user-friendly OAuth CLI

## Sigstore, Cosign
- [notes on Git Hub Action - cosign keyless sign] - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work4\Notes-1.one# Sigstore/Cosign (5)&section-id={1D02D4D6-56CA-42D6-8318-F2060FC425CD}&page-id={D43B7EA6-C868-4DB7-A0B6-1E9F2FB168A1}&end`
- [observe cosign traffic](./2023/cosign-traffic.md)
- [Some notes, (1)~(6)] - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work5\Notes-1.one# Sigstore/Cosign (6)&section-id={2F66D987-20DB-432B-95D1-0351E2341ECC}&page-id={6EED2473-6D7F-45ED-88E7-2A9B218F2B19}&end`
- `cosign`
    - `cosign save`, `cosign tree`
    - use `delve debugger` to trace, remember to remove `-trimpath` when build the binary
    - `dlv exec cosign -- --help`
    - `dlv exec cosign -- triangulate chihjenhuang/cosign1:t1`
- `crane`
    - use `delve debugger` to trace, remember to remove `-trimpath` when build the binary
    - `dlv exec crane -- digest chihjenhuang/cosign1:t1`

## OPA/Rego
- [Rego Debugging Tool](https://github.com/fugue/fregot)
- [opa rego](./2023/opa-rego.md)
- [opa rego, sort arry object by key](./2023/opa-rego-sort-by-array-object.md)
- OPA print function (nice debug mechanism) `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-02.one#2022-07%20Part%20-2&section-id={955E51B5-E20C-4DED-8FB6-5D34F6115376}&page-id={B3BA7FF6-79B0-473C-95EA-4576EF17F33B}&object-id={9A28311D-C346-4431-A976-D09ED4D85875}&B`

## NeuVector
- [Daily dev notes 1](./2023/neuvector-daily-dev-notes-part1.md)
- [NeuVector Onboarding and Best Practices Guide](./documents/_GOOD_NV_Onboarding_5.0.pdf)   
- [how to use minikube, install neuvector and debug](./2023/minikube-howto.md)
- [Install NeuVector steps, start from scratch]
    - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#*%20K8s%20installation&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={4199C511-0482-4B87-A93D-6DD3BC4F143F}&end`
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
- Python CLI - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work5\Notes-1.one#Python%20CLI&section-id={2F66D987-20DB-432B-95D1-0351E2341ECC}&page-id={078BFE7D-2195-49E4-A97E-5F8AA1F29DBF}&end`

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

## React
- [React 17: Getting Started](https://app.pluralsight.com/library/courses/react-js-getting-started/table-of-contents)

## CSS
- list the course I bought from Kevin

## Misc.
- [Vim](./2023/vim-part1.md)
- [SSH Tunnel, connect to host behind NAT](./2023/ssh-tunnel.md)   
- [private registry usage](./2023/private-registry.md)
- [CFSSL CloudFlare's PKI/TLS toolkit](https://github.com/cloudflare/cfssl)
    - [Use CFSSL to generate certificates](https://github.com/marcel-dempers/docker-development-youtube-series/blob/master/kubernetes/admissioncontrollers/introduction/tls/ssl_generate_self_signed.md)
- [Purchased domain, gotalentpool.com, try to apply in my env]
    - `onenote:///C:\Users\Chih-JenHuang\Documents\OneNote%20Notebooks\Work\Notes-01.one#2022-04%20Part-1&section-id={385CC646-19A9-479B-84B9-16C80EAB4662}&page-id={CC7EAB50-073E-4F1A-B813-93A92C95A974}&object-id={7E7F2D08-1FB9-4C77-984F-2C3ADB680E07}&DB`
- How to generate certificate, so it can be used in testing web server, or admission control,,, check the book "Microservices Security in Action", the appendix G
- [generate cert in Makefile](https://github.com/kubernetes/pod-security-admission/tree/master/webhook)