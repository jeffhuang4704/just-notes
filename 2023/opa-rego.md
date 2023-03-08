## OPA and Rego usage

## start opa
```
neuvector@ubuntu2204d:~/opa$ cat 1_start_opa.sh
echo "visit opa server at http://10.1.45.43:8181/v1/data"
opa run --server --ignore=.* --addr=:8181 &
```


## start opa SSL
TODO: add steps to generate the cert
```
// start opa with TLS
opa run --server --log-level debug --tls-cert-file public.crt --tls-private-key-file private.key --addr=:8181
```


## add document to opa and read it back

```
curl -X PUT http://localhost:8181/v1/data/nvdig/k8s/pods --data-binary @allpods.json

// after add, we can get the read via 
neuvector@ubuntu2204d:~/opa$ curl -X PUT http://localhost:8181/v1/data/nvdig/k8s/pods --data-binary @allpods.json
neuvector@ubuntu2204d:~/opa$ curl http://localhost:8181/v1/data/nvdig/k8s
{"result":{"pods":{"apiVersion":"v1","items":[{"metadata":{"creationTimestamp":"2022-11-09T07:18:44Z","generateName"

neuvector@ubuntu2204d:~/opa$ curl http://localhost:8181/v1/data/nvdig/k8s/pods
{"result":{"apiVersion":"v1","items":[{"metadata":{"creationTimestamp":"2022-11-09T07:18:
```

## write rego policy
   - rego read data
   - rego read input (parameter)
```
// prepare json ocument
neuvector@ubuntu2204d:~/ui_pagination$ cat scan_asset.json | more
{"images":{"04e76930489d14c119ca555bcdabcd124819f5302e5403e723d6e2500fceefd

// add document to opa, note the /v1/data URL fragment
neuvector@ubuntu2204d:~/ui_pagination$ curl -X PUT http://localhost:8181/v1/data/asset --data-binary @scan_asset.json

// read it back via
neuvector@ubuntu2204d:~/ui_pagination$ curl http://localhost:8181/v1/data/asset
neuvector@ubuntu2204d:~/ui_pagination$ curl http://localhost:8181/v1/data/asset/images
```

A simple rego policy
```
neuvector@ubuntu2204d:~/opa$ cat play1.rego
package playtest

test[msg]{
    soruce:=["value1","value2","value3"]
    d:=soruce[i]
    msg := sprintf("%v=%v",[i,d])
}

test2[msg]{
    onepod := data.nvdig.k8s.pods.items[i]
    msg := sprintf("%v",[onepod.metadata.name])
}

test3[msg]{
    # record := /v1/data/asset/vulnerabilities
    record := data.asset.vulnerabilities[i]
    msg := sprintf("%v=%v",[i,record.name])
}

test3a[msg]{
    record := data.asset.vulnerabilities[i]
    record.name=="CVE-2019-25013"
    msg := record
}

test4[msg]{
        # read from input (via HTT POST)
        item:=input.filters[i]
        msg := sprintf("%v=%v",[i,item])
}

images[msg]{
    record := data.asset.images[i]
    msg:=record
}

findImageById[msg]{
    image_id:=input.image_id
    images:=data.asset.images[image_id]
    oneImage:=images[i]
    msg:= sprintf("%v",[oneImage.display_name])
}

findHighRiskVulnerabilities[msg]{
    record := data.asset.vulnerabilities[i]
    record.score_v3 > 9.0
    msg := sprintf("%v=%v, score_v3=%v",[i,record.name, record.score_v3])
}
```

Add policy to opa, note the `/v1/policies` URL
```
neuvector@ubuntu2204d:~/opa$ cat 2_apply_rego.sh
curl -X PUT http://localhost:8181/v1/policies/play --data-binary @play1.rego
```

Evaluate rule, without input parameter => using HTTP GET
```
// format for the URL :  /v1/data/{package_name}/{rule_name}
neuvector@ubuntu2204d:~/opa$ curl http://localhost:8181/v1/data/playtest/test
{"result":["0=value1","1=value2","2=value3"]}
```

```
// # access the data 
// test2[msg]{
//    onepod := data.nvdig.k8s.pods.items[i]
//    msg := sprintf("%v",[onepod.metadata.name])
// }

neuvector@ubuntu2204d:~/opa$ curl http://localhost:8181/v1/data/playtest/test2
{"result":["coredns-558bd4d5db-42sp2","coredns-558bd4d5db-lv6bk","etcd-ubuntu2204-e","kube-apiserver-ubuntu2204-e",
```

```
// # access the data

test3[msg]{
    # record := /v1/data/asset/vulnerabilities
    record := data.asset.vulnerabilities[i]
    msg := sprintf("%v=%v",[i,record.name])
}

test3a[msg]{
    record := data.asset.vulnerabilities[i]
    record.name=="CVE-2019-25013"
    msg := record
}

```

## upload rego policy
```
neuvector@ubuntu2204d:~/opa$ cat 2_apply_rego.sh
curl -X PUT http://localhost:8181/v1/policies/play --data-binary @play1.rego
```


## evaluate rego policy without parameter
## evaluate rego policy with parameter (input to rego policy)