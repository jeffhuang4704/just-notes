## cosign related traffic

### verify trace (short version)
- 🏷️ [verify an image using tag (public key) - short version](#verify-an-image-using-tag-public-key---short-version)
- 🏷️ [verify an image using tag (keyless) - short version](#verify-an-image-using-tag-keyless---short-version)
- 🔢 [verify an image using digest (public key) - short version](#verify-an-image-using-digest-public-key---short-version)
- 🔢 [verify an image using digest (keyless) - short version](#verify-an-image-using-digest-keyless---short-version)

### verify trace (complete version)
- 🏷️ [verify an image using tag (public key) - complete trace](#verify-an-image-using-tag-public-key---complete-trace)
- 🏷️ [verify an image using tag (keyless) - complete trace](#verify-an-image-using-tag-keyless---complete-trace)
- 🔢 [verify an image using digest (public key) - complete version]
- 🔢 [verify an image using digest (keyless) - complete version](#verify-an-image-using-digest-keyless---complete-version)

### sign trace
- [sign an image - keypair](#sign-an-image---keypair)

### verify an image using tag (public key) - short version 
```
cosign verify --key cosign.pub chihjenhuang/cosign1:t1 -d
```

```
0️⃣ neuvector@ubuntu2204d:~/play_sigstore/0217$ cosign verify --key cosign.pub chihjenhuang/cosign1:t1 -d

1️⃣ GET https://index.docker.io/v2/
HTTP/1.1 401 Unauthorized

2️⃣ GET https://auth.docker.io/token?scope=repository...
HTTP/1.1 200 OK

3️⃣ GET https://index.docker.io/v2/chihjenhuang/cosign1/manifests/t1
2023/02/17 09:41:00 HTTP/1.1 200 OK
Content-Length: 1570

4️⃣ GET https://index.docker.io/v2/
HTTP/1.1 401 Unauthorized

5️⃣ GET https://auth.docker.io/token?scope=repository
HTTP/1.1 200 OK

6️⃣ GET https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig
2023/02/17 09:41:41 HTTP/1.1 200 OK
Content-Length: 558

7️⃣ GET https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc 
HTTP/1.1 307 Temporary Redirect

8️⃣ GET https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676658661-iL8RZAoYgcwML%2FjTAwv5bNKth4E%3D [body redacted: omitting binary blobs from logs]
2023/02/17 09:41:01 GET /registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676658661-iL8RZAoYgcwML%2FjTAwv5bNKth4E%3D HTTP/1.1
HTTP/2.0 200 OK
Content-Length: 252

👉 Verification for index.docker.io/chihjenhuang/cosign1:t1 --
The following checks were performed on each of these signatures:
  - The cosign claims were validated
  - The signatures were verified against the specified public key

[{"critical":{"identity":{"docker-reference":"index.docker.io/chihjenhuang/cosign1"},"image":{"docker-manifest-digest":"sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d"},"type":"cosign container image signature"},"optional":null}]

```


### verify an image using tag (keyless) - short version
```
TODO
```

### verify an image using digest (public key) - short version
```
cosign verify --key cosign.pub chihjenhuang/cosign1@sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d -d
```
  searchme1
```
```

### verify an image using digest (keyless) - short version  
```
TODO
```
searchme2

### verify an image using tag (public key) - complete trace 
```
cosign verify --key cosign.pub chihjenhuang/cosign1:t1 -d
```


```
0️⃣ neuvector@ubuntu2204d:~/play_sigstore/0217$ cosign verify --key cosign.pub chihjenhuang/cosign1:t1 -d

1️⃣ 2023/02/17 09:41:00 --> GET https://index.docker.io/v2/
2023/02/17 09:41:00 GET /v2/ HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept-Encoding: gzip


2023/02/17 09:41:00 <-- 401 https://index.docker.io/v2/ (348.666863ms)
2023/02/17 09:41:00 HTTP/1.1 401 Unauthorized
Content-Length: 87
Content-Type: application/json
Date: Fri, 17 Feb 2023 17:41:00 GMT
Docker-Distribution-Api-Version: registry/2.0
Strict-Transport-Security: max-age=31536000
Www-Authenticate: Bearer realm="https://auth.docker.io/token",service="registry.docker.io"

{"errors":[{"code":"UNAUTHORIZED","message":"authentication required","detail":null}]}

2️⃣ 2023/02/17 09:41:00 --> GET https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io [body redacted: basic token response contains credentials]
2023/02/17 09:41:00 GET /token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io HTTP/1.1
Host: auth.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:41:00 <-- 200 https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io (263.696562ms) [body redacted: basic token response contains credentials]
2023/02/17 09:41:00 HTTP/1.1 200 OK
Transfer-Encoding: chunked
Content-Type: application/json; charset=utf-8
Date: Fri, 17 Feb 2023 17:41:00 GMT
Strict-Transport-Security: max-age=31536000
X-Trace-Id: f0ead641983cd230e1b2ccb1c492f3a2


3️⃣ 2023/02/17 09:41:00 --> GET https://index.docker.io/v2/chihjenhuang/cosign1/manifests/t1
2023/02/17 09:41:00 GET /v2/chihjenhuang/cosign1/manifests/t1 HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept: application/vnd.docker.distribution.manifest.v1+json,application/vnd.docker.distribution.manifest.v1+prettyjws,application/vnd.docker.distribution.manifest.v2+json,application/vnd.oci.image.manifest.v1+json,application/vnd.docker.distribution.manifest.list.v2+json,application/vnd.oci.image.index.v1+json
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:41:00 <-- 200 https://index.docker.io/v2/chihjenhuang/cosign1/manifests/t1 (124.417513ms)
2023/02/17 09:41:00 HTTP/1.1 200 OK
Content-Length: 1570
Content-Type: application/vnd.docker.distribution.manifest.v2+json
Date: Fri, 17 Feb 2023 17:41:00 GMT
Docker-Content-Digest: sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d
Docker-Distribution-Api-Version: registry/2.0
Docker-Ratelimit-Source: aa244511-db56-4b1d-9536-8249869527c1
Etag: "sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d"
Ratelimit-Limit: 200;w=21600
Ratelimit-Remaining: 197;w=21600
Strict-Transport-Security: max-age=31536000

{
   "schemaVersion": 2,
   "mediaType": "application/vnd.docker.distribution.manifest.v2+json",
   "config": {
      "mediaType": "application/vnd.docker.container.image.v1+json",
      "size": 7656,
      "digest": "sha256:a99a39d070bfd1cb60fe65c45dea3a33764dc00a9546bf8dc46cb5a11b1b50e9"
   },
   "layers": [
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 31396972,
         "digest": "sha256:8740c948ffd4c816ea7ca963f99ca52f4788baa23f228da9581a9ea2edd3fcd7"
      },
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 25470551,
         "digest": "sha256:d2c0556a17c5d136fc0387f936672d6922c0ee0c412e39f10bdb9abea3790815"
      },
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 626,
         "digest": "sha256:c8b9881f2c6a7c0a4b133402af9b73c6d7f481ac9b455f6f96e6181f12a8a78a"
      },
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 958,
         "digest": "sha256:693c3ffa8f43a3ae70d512c7add694b6c66a3d69262c4433acd3e0aa6d0d8b8b"
      },
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 772,
         "digest": "sha256:8316c5e80e6d3abc453220bd5858bb7bd5ac08d8b79a13378b500d6e70f91c1d"
      },
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 1404,
         "digest": "sha256:b2fe3577faa434a4ca212810cb5d245ab0923d078b44d17f9e26609772f655bf"
      }
   ]
}
4️⃣ 2023/02/17 09:41:00 --> GET https://index.docker.io/v2/
2023/02/17 09:41:00 GET /v2/ HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept-Encoding: gzip


2023/02/17 09:41:01 <-- 401 https://index.docker.io/v2/ (78.662672ms)
2023/02/17 09:41:01 HTTP/1.1 401 Unauthorized
Content-Length: 87
Content-Type: application/json
Date: Fri, 17 Feb 2023 17:41:00 GMT
Docker-Distribution-Api-Version: registry/2.0
Strict-Transport-Security: max-age=31536000
Www-Authenticate: Bearer realm="https://auth.docker.io/token",service="registry.docker.io"

{"errors":[{"code":"UNAUTHORIZED","message":"authentication required","detail":null}]}

5️⃣ 2023/02/17 09:41:01 --> GET https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io [body redacted: basic token response contains credentials]
2023/02/17 09:41:01 GET /token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io HTTP/1.1
Host: auth.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:41:01 <-- 200 https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io (98.532597ms) [body redacted: basic token response contains credentials]
2023/02/17 09:41:01 HTTP/1.1 200 OK
Transfer-Encoding: chunked
Content-Type: application/json; charset=utf-8
Date: Fri, 17 Feb 2023 17:41:01 GMT
Strict-Transport-Security: max-age=31536000
X-Trace-Id: 03ccf6af66d12f2548bedeaf6ccdb9bf


6️⃣ 2023/02/17 09:41:01 --> GET https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig
2023/02/17 09:41:01 GET /v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept: application/vnd.docker.distribution.manifest.v1+json,application/vnd.docker.distribution.manifest.v1+prettyjws,application/vnd.docker.distribution.manifest.v2+json,application/vnd.oci.image.manifest.v1+json,application/vnd.docker.distribution.manifest.list.v2+json,application/vnd.oci.image.index.v1+json
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:41:41 <-- 200 https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig (159.544908ms)
2023/02/17 09:41:41 HTTP/1.1 200 OK
Content-Length: 558
Content-Type: application/vnd.oci.image.manifest.v1+json
Date: Fri, 17 Feb 2023 17:41:01 GMT
Docker-Content-Digest: sha256:7ebe8964225fa4619b53aa35416ef0246c037e36ddf81776b21b15e1dda2262b
Docker-Distribution-Api-Version: registry/2.0
Docker-Ratelimit-Source: aa244511-db56-4b1d-9536-8249869527c1
Etag: "sha256:7ebe8964225fa4619b53aa35416ef0246c037e36ddf81776b21b15e1dda2262b"
Ratelimit-Limit: 200;w=21600
Ratelimit-Remaining: 197;w=21600
Strict-Transport-Security: max-age=31536000

{"schemaVersion":2,"mediaType":"application/vnd.oci.image.manifest.v1+json","config":{"mediaType":"application/vnd.oci.image.config.v1+json","size":247,"digest":"sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95"},"layers":[{"mediaType":"application/vnd.dev.cosign.simplesigning.v1+json","size":252,"digest":"sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc","annotations":{"dev.cosignproject.cosign/signature":"MEYCIQCPH7NJAIfrB6BZN91dV0o7l/i11muXrvrAh100jDMMhAIhAPsLH0oXb2OPITXRpWBMUd3vHtz5Ks5pql2Hr6t/IJXw"}}]}
7️⃣ 2023/02/17 09:41:41 --> GET https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc [body redacted: omitting binary blobs from logs]
2023/02/17 09:41:41 GET /v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:41:01 <-- 307 https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc (81.598627ms) [body redacted: omitting binary blobs from logs]
2023/02/17 09:41:01 HTTP/1.1 307 Temporary Redirect
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 17:41:01 GMT
Docker-Distribution-Api-Version: registry/2.0
Location: https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676658661-iL8RZAoYgcwML%2FjTAwv5bNKth4E%3D
Strict-Transport-Security: max-age=31536000
Content-Length: 0


8️⃣ 2023/02/17 09:41:01 GET /registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676658661-iL8RZAoYgcwML%2FjTAwv5bNKth4E%3D HTTP/1.1
Host: production.cloudflare.docker.com
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Referer: https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc
Accept-Encoding: gzip


2023/02/17 09:41:01 <-- 200 https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676658661-iL8RZAoYgcwML%2FjTAwv5bNKth4E%3D (216.491782ms) [body redacted: omitting binary blobs from logs]
2023/02/17 09:41:01 HTTP/2.0 200 OK
Content-Length: 252
Accept-Ranges: bytes
Cache-Control: public, max-age=14400
Cf-Cache-Status: HIT
Cf-Ray: 79b04fbc2d776438-SJC
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 17:41:01 GMT
Etag: "0390a29c82c60bbd5463f649ce9b2a4f"
Expires: Fri, 17 Feb 2023 21:41:01 GMT
Last-Modified: Fri, 17 Feb 2023 16:53:35 GMT
Server: cloudflare
Vary: Accept-Encoding
X-Amz-Id-2: I4zZB5QuXWezAdbtuRAqzvNhkQVuumyX/NzsByuooVK0ZHVukjqluwHq7Rj1U+1SRaMJjj33U08=
X-Amz-Request-Id: VBQ4RHEPE0MPDQFN
X-Amz-Version-Id: q.9iy1J1iGELKxpcUaIyg.DQZQV6yGGO



👉 Verification for index.docker.io/chihjenhuang/cosign1:t1 --
The following checks were performed on each of these signatures:
  - The cosign claims were validated
  - The signatures were verified against the specified public key

[{"critical":{"identity":{"docker-reference":"index.docker.io/chihjenhuang/cosign1"},"image":{"docker-manifest-digest":"sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d"},"type":"cosign container image signature"},"optional":null}]
```

### verify an image using digest (public key)

```
# command
# use -d to observe the traffic
cosign verify --key cosign.pub chihjenhuang/cosign1@sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d -d

```

```
👉 neuvector@ubuntu2204d:~/play_sigstore/0217$ cosign verify --key cosign.pub chihjenhuang/cosign1@sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d -d
2023/02/17 09:35:48 --> GET https://index.docker.io/v2/
2023/02/17 09:35:48 GET /v2/ HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept-Encoding: gzip


2023/02/17 09:35:48 <-- 401 https://index.docker.io/v2/ (337.735191ms)
2023/02/17 09:35:48 HTTP/1.1 401 Unauthorized
Content-Length: 87
Content-Type: application/json
Date: Fri, 17 Feb 2023 17:35:48 GMT
Docker-Distribution-Api-Version: registry/2.0
Strict-Transport-Security: max-age=31536000
Www-Authenticate: Bearer realm="https://auth.docker.io/token",service="registry.docker.io"

{"errors":[{"code":"UNAUTHORIZED","message":"authentication required","detail":null}]}

2023/02/17 09:35:48 --> GET https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io [body redacted: basic token response contains credentials]
2023/02/17 09:35:48 GET /token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io HTTP/1.1
Host: auth.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:35:48 <-- 200 https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io (263.789011ms) [body redacted: basic token response contains credentials]
2023/02/17 09:35:48 HTTP/1.1 200 OK
Transfer-Encoding: chunked
Content-Type: application/json; charset=utf-8
Date: Fri, 17 Feb 2023 17:35:48 GMT
Strict-Transport-Security: max-age=31536000
X-Trace-Id: 09d23ac69b21e2c9f4827f26276e6a26


👉 2023/02/17 09:35:48 --> GET https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig
2023/02/17 09:35:48 GET /v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept: application/vnd.docker.distribution.manifest.v1+json,application/vnd.docker.distribution.manifest.v1+prettyjws,application/vnd.docker.distribution.manifest.v2+json,application/vnd.oci.image.manifest.v1+json,application/vnd.docker.distribution.manifest.list.v2+json,application/vnd.oci.image.index.v1+json
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:35:48 <-- 200 https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig (147.847789ms)
2023/02/17 09:35:48 HTTP/1.1 200 OK
Content-Length: 558
Content-Type: application/vnd.oci.image.manifest.v1+json
Date: Fri, 17 Feb 2023 17:35:48 GMT
Docker-Content-Digest: sha256:7ebe8964225fa4619b53aa35416ef0246c037e36ddf81776b21b15e1dda2262b
Docker-Distribution-Api-Version: registry/2.0
Docker-Ratelimit-Source: aa244511-db56-4b1d-9536-8249869527c1
Etag: "sha256:7ebe8964225fa4619b53aa35416ef0246c037e36ddf81776b21b15e1dda2262b"
Ratelimit-Limit: 200;w=21600
Ratelimit-Remaining: 198;w=21600
Strict-Transport-Security: max-age=31536000

{"schemaVersion":2,"mediaType":"application/vnd.oci.image.manifest.v1+json","config":{"mediaType":"application/vnd.oci.image.config.v1+json","size":247,"digest":"sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95"},"layers":[{"mediaType":"application/vnd.dev.cosign.simplesigning.v1+json","size":252,"digest":"sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc","annotations":{"dev.cosignproject.cosign/signature":"MEYCIQCPH7NJAIfrB6BZN91dV0o7l/i11muXrvrAh100jDMMhAIhAPsLH0oXb2OPITXRpWBMUd3vHtz5Ks5pql2Hr6t/IJXw"}}]}
2023/02/17 09:35:48 --> GET https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc [body redacted: omitting binary blobs from logs]
2023/02/17 09:35:48 GET /v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:35:48 <-- 307 https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc (82.482226ms) [body redacted: omitting binary blobs from logs]
2023/02/17 09:35:48 HTTP/1.1 307 Temporary Redirect
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 17:35:48 GMT
Docker-Distribution-Api-Version: registry/2.0
Location: https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676658348-P%2BMKUijFOYZrnENs4GG6ziNF1ec%3D
Strict-Transport-Security: max-age=31536000
Content-Length: 0


2023/02/17 09:35:48 --> GET https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676658348-P%2BMKUijFOYZrnENs4GG6ziNF1ec%3D [body redacted: omitting binary blobs from logs]
2023/02/17 09:35:48 GET /registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676658348-P%2BMKUijFOYZrnENs4GG6ziNF1ec%3D HTTP/1.1
Host: production.cloudflare.docker.com
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Referer: https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc
Accept-Encoding: gzip


2023/02/17 09:35:49 <-- 200 https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676658348-P%2BMKUijFOYZrnENs4GG6ziNF1ec%3D (471.253336ms) [body redacted: omitting binary blobs from logs]
2023/02/17 09:35:49 HTTP/2.0 200 OK
Content-Length: 252
Accept-Ranges: bytes
Cache-Control: public, max-age=14400
Cf-Cache-Status: HIT
Cf-Ray: 79b0481b8d6bce60-SJC
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 17:35:49 GMT
Etag: "0390a29c82c60bbd5463f649ce9b2a4f"
Expires: Fri, 17 Feb 2023 21:35:49 GMT
Last-Modified: Fri, 17 Feb 2023 16:53:35 GMT
Server: cloudflare
Vary: Accept-Encoding
X-Amz-Id-2: I4zZB5QuXWezAdbtuRAqzvNhkQVuumyX/NzsByuooVK0ZHVukjqluwHq7Rj1U+1SRaMJjj33U08=
X-Amz-Request-Id: VBQ4RHEPE0MPDQFN
X-Amz-Version-Id: q.9iy1J1iGELKxpcUaIyg.DQZQV6yGGO



Verification for index.docker.io/chihjenhuang/cosign1@sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d --
The following checks were performed on each of these signatures:
  - The cosign claims were validated
  - The signatures were verified against the specified public key

[{"critical":{"identity":{"docker-reference":"index.docker.io/chihjenhuang/cosign1"},"image":{"docker-manifest-digest":"sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d"},"type":"cosign container image signature"},"optional":null}]
```

### verify an image using tag (keyless) - complete trace
```
TODO
```

### verify an image using digest (public key) - complete version
```
cosign verify --key cosign.pub chihjenhuang/cosign1@sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d -d 
```
searchme3
```
neuvector@ubuntu2204d:~/play_sigstore/0217$ cosign verify --key cosign.pub chihjenhuang/cosign1@sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d -d
2023/02/17 11:01:05 --> GET https://index.docker.io/v2/
2023/02/17 11:01:05 GET /v2/ HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept-Encoding: gzip


2023/02/17 11:01:10 <-- dial tcp: lookup index.docker.io: i/o timeout GET https://index.docker.io/v2/ (5.000872329s)
2023/02/17 11:01:10 --> GET https://index.docker.io/v2/
2023/02/17 11:01:10 GET /v2/ HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept-Encoding: gzip


2023/02/17 11:01:10 <-- 401 https://index.docker.io/v2/ (303.866248ms)
2023/02/17 11:01:10 HTTP/1.1 401 Unauthorized
Content-Length: 87
Content-Type: application/json
Date: Fri, 17 Feb 2023 19:01:10 GMT
Docker-Distribution-Api-Version: registry/2.0
Strict-Transport-Security: max-age=31536000
Www-Authenticate: Bearer realm="https://auth.docker.io/token",service="registry.docker.io"

{"errors":[{"code":"UNAUTHORIZED","message":"authentication required","detail":null}]}

2023/02/17 11:01:10 --> GET https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io [body redacted: basic token response contains credentials]
2023/02/17 11:01:10 GET /token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io HTTP/1.1
Host: auth.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 11:01:10 <-- 200 https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io (252.36884ms) [body redacted: basic token response contains credentials]
2023/02/17 11:01:10 HTTP/1.1 200 OK
Transfer-Encoding: chunked
Content-Type: application/json; charset=utf-8
Date: Fri, 17 Feb 2023 19:01:10 GMT
Strict-Transport-Security: max-age=31536000
X-Trace-Id: bb31111e801ef14b6bb11b58242601f1


2023/02/17 11:01:10 --> GET https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig
2023/02/17 11:01:10 GET /v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept: application/vnd.docker.distribution.manifest.v1+json,application/vnd.docker.distribution.manifest.v1+prettyjws,application/vnd.docker.distribution.manifest.v2+json,application/vnd.oci.image.manifest.v1+json,application/vnd.docker.distribution.manifest.list.v2+json,application/vnd.oci.image.index.v1+json
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 11:01:10 <-- 200 https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig (119.641873ms)
2023/02/17 11:01:10 HTTP/1.1 200 OK
Content-Length: 558
Content-Type: application/vnd.oci.image.manifest.v1+json
Date: Fri, 17 Feb 2023 19:01:10 GMT
Docker-Content-Digest: sha256:7ebe8964225fa4619b53aa35416ef0246c037e36ddf81776b21b15e1dda2262b
Docker-Distribution-Api-Version: registry/2.0
Docker-Ratelimit-Source: aa244511-db56-4b1d-9536-8249869527c1
Etag: "sha256:7ebe8964225fa4619b53aa35416ef0246c037e36ddf81776b21b15e1dda2262b"
Ratelimit-Limit: 200;w=21600
Ratelimit-Remaining: 195;w=21600
Strict-Transport-Security: max-age=31536000

{"schemaVersion":2,"mediaType":"application/vnd.oci.image.manifest.v1+json","config":{"mediaType":"application/vnd.oci.image.config.v1+json","size":247,"digest":"sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95"},"layers":[{"mediaType":"application/vnd.dev.cosign.simplesigning.v1+json","size":252,"digest":"sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc","annotations":{"dev.cosignproject.cosign/signature":"MEYCIQCPH7NJAIfrB6BZN91dV0o7l/i11muXrvrAh100jDMMhAIhAPsLH0oXb2OPITXRpWBMUd3vHtz5Ks5pql2Hr6t/IJXw"}}]}
2023/02/17 11:01:10 --> GET https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc [body redacted: omitting binary blobs from logs]
2023/02/17 11:01:10 GET /v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 11:01:11 <-- 307 https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc (80.658845ms) [body redacted: omitting binary blobs from logs]
2023/02/17 11:01:11 HTTP/1.1 307 Temporary Redirect
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 19:01:11 GMT
Docker-Distribution-Api-Version: registry/2.0
Location: https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676663471-kiACVxj5NdwgP1N5CBdwpkEtMi8%3D
Strict-Transport-Security: max-age=31536000
Content-Length: 0


2023/02/17 11:01:11 --> GET https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676663471-kiACVxj5NdwgP1N5CBdwpkEtMi8%3D [body redacted: omitting binary blobs from logs]
2023/02/17 11:01:11 GET /registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676663471-kiACVxj5NdwgP1N5CBdwpkEtMi8%3D HTTP/1.1
Host: production.cloudflare.docker.com
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Referer: https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc
Accept-Encoding: gzip


2023/02/17 11:01:11 <-- 200 https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676663471-kiACVxj5NdwgP1N5CBdwpkEtMi8%3D (144.39281ms) [body redacted: omitting binary blobs from logs]
2023/02/17 11:01:11 HTTP/2.0 200 OK
Content-Length: 252
Accept-Ranges: bytes
Age: 4810
Cache-Control: public, max-age=14400
Cf-Cache-Status: HIT
Cf-Ray: 79b0c528ddfd9435-SJC
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 19:01:11 GMT
Etag: "0390a29c82c60bbd5463f649ce9b2a4f"
Expires: Fri, 17 Feb 2023 23:01:11 GMT
Last-Modified: Fri, 17 Feb 2023 16:53:35 GMT
Server: cloudflare
Vary: Accept-Encoding
X-Amz-Id-2: I4zZB5QuXWezAdbtuRAqzvNhkQVuumyX/NzsByuooVK0ZHVukjqluwHq7Rj1U+1SRaMJjj33U08=
X-Amz-Request-Id: VBQ4RHEPE0MPDQFN
X-Amz-Version-Id: q.9iy1J1iGELKxpcUaIyg.DQZQV6yGGO



Verification for index.docker.io/chihjenhuang/cosign1@sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d --
The following checks were performed on each of these signatures:
  - The cosign claims were validated
  - The signatures were verified against the specified public key

[{"critical":{"identity":{"docker-reference":"index.docker.io/chihjenhuang/cosign1"},"image":{"docker-manifest-digest":"sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d"},"type":"cosign container image signature"},"optional":null}]
```

### verify an image using digest (keyless) - complete version
```
TODO
```


### sign an image - keypair

```
# command
# use -d to observe the traffic

cosign sign --key cosign.key chihjenhuang/cosign1@sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d -d
```


```
👉 neuvector@ubuntu2204d:~/play_sigstore/0217$ cosign sign --key cosign.key chihjenhuang/cosign1@sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d -d
Enter password for private key:
2023/02/17 09:28:03 --> GET https://index.docker.io/v2/
2023/02/17 09:28:03 GET /v2/ HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept-Encoding: gzip


2023/02/17 09:28:03 <-- 401 https://index.docker.io/v2/ (325.832911ms)
2023/02/17 09:28:03 HTTP/1.1 401 Unauthorized
Content-Length: 87
Content-Type: application/json
Date: Fri, 17 Feb 2023 17:28:03 GMT
Docker-Distribution-Api-Version: registry/2.0
Strict-Transport-Security: max-age=31536000
Www-Authenticate: Bearer realm="https://auth.docker.io/token",service="registry.docker.io"

{"errors":[{"code":"UNAUTHORIZED","message":"authentication required","detail":null}]}

2023/02/17 09:28:03 --> GET https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io [body redacted: basic token response contains credentials]
2023/02/17 09:28:03 GET /token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io HTTP/1.1
Host: auth.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:28:03 <-- 200 https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io (284.728627ms) [body redacted: basic token response contains credentials]
2023/02/17 09:28:03 HTTP/1.1 200 OK
Transfer-Encoding: chunked
Content-Type: application/json; charset=utf-8
Date: Fri, 17 Feb 2023 17:28:03 GMT
Strict-Transport-Security: max-age=31536000
X-Trace-Id: 313a56b8692e64377e5a0348bf01f6a8


👉 2023/02/17 09:28:03 --> GET https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d
2023/02/17 09:28:03 GET /v2/chihjenhuang/cosign1/manifests/sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept: application/vnd.docker.distribution.manifest.v1+json,application/vnd.docker.distribution.manifest.v1+prettyjws,application/vnd.docker.distribution.manifest.v2+json,application/vnd.oci.image.manifest.v1+json,application/vnd.docker.distribution.manifest.list.v2+json,application/vnd.oci.image.index.v1+json
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:28:03 <-- 200 https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d (111.800245ms)
2023/02/17 09:28:03 HTTP/1.1 200 OK
Content-Length: 1570
Content-Type: application/vnd.docker.distribution.manifest.v2+json
Date: Fri, 17 Feb 2023 17:28:03 GMT
Docker-Content-Digest: sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d
Docker-Distribution-Api-Version: registry/2.0
Docker-Ratelimit-Source: aa244511-db56-4b1d-9536-8249869527c1
Etag: "sha256:4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d"
Ratelimit-Limit: 200;w=21600
Ratelimit-Remaining: 199;w=21600
Strict-Transport-Security: max-age=31536000

{
   "schemaVersion": 2,
   "mediaType": "application/vnd.docker.distribution.manifest.v2+json",
   "config": {
      "mediaType": "application/vnd.docker.container.image.v1+json",
      "size": 7656,
      "digest": "sha256:a99a39d070bfd1cb60fe65c45dea3a33764dc00a9546bf8dc46cb5a11b1b50e9"
   },
   "layers": [
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 31396972,
         "digest": "sha256:8740c948ffd4c816ea7ca963f99ca52f4788baa23f228da9581a9ea2edd3fcd7"
      },
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 25470551,
         "digest": "sha256:d2c0556a17c5d136fc0387f936672d6922c0ee0c412e39f10bdb9abea3790815"
      },
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 626,
         "digest": "sha256:c8b9881f2c6a7c0a4b133402af9b73c6d7f481ac9b455f6f96e6181f12a8a78a"
      },
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 958,
         "digest": "sha256:693c3ffa8f43a3ae70d512c7add694b6c66a3d69262c4433acd3e0aa6d0d8b8b"
      },
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 772,
         "digest": "sha256:8316c5e80e6d3abc453220bd5858bb7bd5ac08d8b79a13378b500d6e70f91c1d"
      },
      {
         "mediaType": "application/vnd.docker.image.rootfs.diff.tar.gzip",
         "size": 1404,
         "digest": "sha256:b2fe3577faa434a4ca212810cb5d245ab0923d078b44d17f9e26609772f655bf"
      }
   ]
}

👉👉👉 Pushing signature to: index.docker.io/chihjenhuang/cosign1
2023/02/17 09:28:03 --> GET https://index.docker.io/v2/
2023/02/17 09:28:03 GET /v2/ HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept-Encoding: gzip


2023/02/17 09:28:03 <-- 401 https://index.docker.io/v2/ (75.400514ms)
2023/02/17 09:28:03 HTTP/1.1 401 Unauthorized
Content-Length: 87
Content-Type: application/json
Date: Fri, 17 Feb 2023 17:28:03 GMT
Docker-Distribution-Api-Version: registry/2.0
Strict-Transport-Security: max-age=31536000
Www-Authenticate: Bearer realm="https://auth.docker.io/token",service="registry.docker.io"

{"errors":[{"code":"UNAUTHORIZED","message":"authentication required","detail":null}]}

2023/02/17 09:28:03 --> GET https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io [body redacted: basic token response contains credentials]
2023/02/17 09:28:03 GET /token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io HTTP/1.1
Host: auth.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:28:03 <-- 200 https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apull&service=registry.docker.io (110.919065ms) [body redacted: basic token response contains credentials]
2023/02/17 09:28:03 HTTP/1.1 200 OK
Transfer-Encoding: chunked
Content-Type: application/json; charset=utf-8
Date: Fri, 17 Feb 2023 17:28:03 GMT
Strict-Transport-Security: max-age=31536000
X-Trace-Id: e504dfed030366a954ccb5f93f850c92


2023/02/17 09:28:03 --> GET https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig
2023/02/17 09:28:03 GET /v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept: application/vnd.docker.distribution.manifest.v1+json,application/vnd.docker.distribution.manifest.v1+prettyjws,application/vnd.docker.distribution.manifest.v2+json,application/vnd.oci.image.manifest.v1+json,application/vnd.docker.distribution.manifest.list.v2+json,application/vnd.oci.image.index.v1+json
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:28:04 <-- 200 https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig (127.30211ms)
2023/02/17 09:28:04 HTTP/1.1 200 OK
Content-Length: 558
Content-Type: application/vnd.oci.image.manifest.v1+json
Date: Fri, 17 Feb 2023 17:28:04 GMT
Docker-Content-Digest: sha256:7ebe8964225fa4619b53aa35416ef0246c037e36ddf81776b21b15e1dda2262b
Docker-Distribution-Api-Version: registry/2.0
Docker-Ratelimit-Source: aa244511-db56-4b1d-9536-8249869527c1
Etag: "sha256:7ebe8964225fa4619b53aa35416ef0246c037e36ddf81776b21b15e1dda2262b"
Ratelimit-Limit: 200;w=21600
Ratelimit-Remaining: 198;w=21600
Strict-Transport-Security: max-age=31536000

{"schemaVersion":2,"mediaType":"application/vnd.oci.image.manifest.v1+json","config":{"mediaType":"application/vnd.oci.image.config.v1+json","size":247,"digest":"sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95"},"layers":[{"mediaType":"application/vnd.dev.cosign.simplesigning.v1+json","size":252,"digest":"sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc","annotations":{"dev.cosignproject.cosign/signature":"MEYCIQCPH7NJAIfrB6BZN91dV0o7l/i11muXrvrAh100jDMMhAIhAPsLH0oXb2OPITXRpWBMUd3vHtz5Ks5pql2Hr6t/IJXw"}}]}
2023/02/17 09:28:04 --> GET https://index.docker.io/v2/
2023/02/17 09:28:04 GET /v2/ HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Accept-Encoding: gzip


2023/02/17 09:28:04 <-- 401 https://index.docker.io/v2/ (75.578947ms)
2023/02/17 09:28:04 HTTP/1.1 401 Unauthorized
Content-Length: 87
Content-Type: application/json
Date: Fri, 17 Feb 2023 17:28:04 GMT
Docker-Distribution-Api-Version: registry/2.0
Strict-Transport-Security: max-age=31536000
Www-Authenticate: Bearer realm="https://auth.docker.io/token",service="registry.docker.io"

{"errors":[{"code":"UNAUTHORIZED","message":"authentication required","detail":null}]}

2023/02/17 09:28:04 --> GET https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apush%2Cpull&service=registry.docker.io [body redacted: basic token response contains credentials]
2023/02/17 09:28:04 GET /token?scope=repository%3Achihjenhuang%2Fcosign1%3Apush%2Cpull&service=registry.docker.io HTTP/1.1
Host: auth.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:28:04 <-- 200 https://auth.docker.io/token?scope=repository%3Achihjenhuang%2Fcosign1%3Apush%2Cpull&service=registry.docker.io (94.671902ms) [body redacted: basic token response contains credentials]
2023/02/17 09:28:04 HTTP/1.1 200 OK
Transfer-Encoding: chunked
Content-Type: application/json; charset=utf-8
Date: Fri, 17 Feb 2023 17:28:04 GMT
Strict-Transport-Security: max-age=31536000
X-Trace-Id: 9e880dfb8d4179773014cd75963e2967


2023/02/17 09:28:04 --> GET https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95
2023/02/17 09:28:04 GET /v2/chihjenhuang/cosign1/blobs/sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95 HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>
Accept-Encoding: gzip


2023/02/17 09:28:04 --> HEAD https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc
2023/02/17 09:28:04 HEAD /v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>


2023/02/17 09:28:04 <-- 307 https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95 (85.574218ms)
2023/02/17 09:28:04 HTTP/1.1 307 Temporary Redirect
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 17:28:04 GMT
Docker-Distribution-Api-Version: registry/2.0
Location: https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/85/85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95/data?verify=1676657884-FcRw%2BcmVyS9UfSxcXpA5zXcpY2A%3D
Strict-Transport-Security: max-age=31536000
Content-Length: 0


2023/02/17 09:28:04 --> GET https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/85/85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95/data?verify=1676657884-FcRw%2BcmVyS9UfSxcXpA5zXcpY2A%3D
2023/02/17 09:28:04 GET /registry-v2/docker/registry/v2/blobs/sha256/85/85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95/data?verify=1676657884-FcRw%2BcmVyS9UfSxcXpA5zXcpY2A%3D HTTP/1.1
Host: production.cloudflare.docker.com
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Referer: https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95
Accept-Encoding: gzip


2023/02/17 09:28:04 <-- 307 https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc (167.749965ms)
2023/02/17 09:28:04 HTTP/1.1 307 Temporary Redirect
Connection: close
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 17:28:04 GMT
Docker-Distribution-Api-Version: registry/2.0
Location: https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676657884-qQ5sRgIR2lYFrre6HCATedPjXw8%3D
Strict-Transport-Security: max-age=31536000


2023/02/17 09:28:04 --> HEAD https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676657884-qQ5sRgIR2lYFrre6HCATedPjXw8%3D
2023/02/17 09:28:04 HEAD /registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676657884-qQ5sRgIR2lYFrre6HCATedPjXw8%3D HTTP/1.1
Host: production.cloudflare.docker.com
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Referer: https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc


2023/02/17 09:28:04 <-- 200 https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/85/85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95/data?verify=1676657884-FcRw%2BcmVyS9UfSxcXpA5zXcpY2A%3D (386.589571ms)
2023/02/17 09:28:04 HTTP/2.0 200 OK
Content-Length: 247
Accept-Ranges: bytes
Cache-Control: public, max-age=14400
Cf-Cache-Status: MISS
Cf-Ray: 79b03cc3fde697f7-SJC
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 17:28:04 GMT
Etag: "e52091fe9a6df3f9cb034e61f2e4a7dd"
Expires: Fri, 17 Feb 2023 21:28:04 GMT
Last-Modified: Fri, 17 Feb 2023 17:25:36 GMT
Server: cloudflare
Vary: Accept-Encoding
X-Amz-Id-2: md3LpfFBwzhgz7CrlehH2mrWlIfmZiZuK0gAtUvB0l3ATUq9vXzIfx52ly2ycAnO2iPk3Kp5xEM=
X-Amz-Request-Id: W2G81PPSF4QS3B2A
X-Amz-Version-Id: irnkL89fqEtE64wLeU6wjuDz2yuRewUj

{"architecture":"","created":"2023-02-17T09:25:33.91047962-08:00","history":[{"created":"0001-01-01T00:00:00Z"}],"os":"","rootfs":{"type":"layers","diff_ids":["sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc"]},"config":{}}
2023/02/17 09:28:04 --> HEAD https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95
2023/02/17 09:28:04 HEAD /v2/chihjenhuang/cosign1/blobs/sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95 HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Authorization: <redacted>


2023/02/17 09:28:04 <-- 200 https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/b6/b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc/data?verify=1676657884-qQ5sRgIR2lYFrre6HCATedPjXw8%3D (339.069532ms)
2023/02/17 09:28:04 HTTP/2.0 200 OK
Content-Length: 252
Accept-Ranges: bytes
Cache-Control: public, max-age=14400
Cf-Cache-Status: HIT
Cf-Ray: 79b03cc3ede597f7-SJC
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 17:28:04 GMT
Etag: "0390a29c82c60bbd5463f649ce9b2a4f"
Expires: Fri, 17 Feb 2023 21:28:04 GMT
Last-Modified: Fri, 17 Feb 2023 16:53:35 GMT
Server: cloudflare
Vary: Accept-Encoding
X-Amz-Id-2: I4zZB5QuXWezAdbtuRAqzvNhkQVuumyX/NzsByuooVK0ZHVukjqluwHq7Rj1U+1SRaMJjj33U08=
X-Amz-Request-Id: VBQ4RHEPE0MPDQFN
X-Amz-Version-Id: q.9iy1J1iGELKxpcUaIyg.DQZQV6yGGO


2023/02/17 09:28:04 <-- 307 https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95 (83.15512ms)
2023/02/17 09:28:04 HTTP/1.1 307 Temporary Redirect
Connection: close
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 17:28:04 GMT
Docker-Distribution-Api-Version: registry/2.0
Location: https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/85/85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95/data?verify=1676657884-FcRw%2BcmVyS9UfSxcXpA5zXcpY2A%3D
Strict-Transport-Security: max-age=31536000


2023/02/17 09:28:04 --> HEAD https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/85/85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95/data?verify=1676657884-FcRw%2BcmVyS9UfSxcXpA5zXcpY2A%3D
2023/02/17 09:28:04 HEAD /registry-v2/docker/registry/v2/blobs/sha256/85/85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95/data?verify=1676657884-FcRw%2BcmVyS9UfSxcXpA5zXcpY2A%3D HTTP/1.1
Host: production.cloudflare.docker.com
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Referer: https://index.docker.io/v2/chihjenhuang/cosign1/blobs/sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95


2023/02/17 09:28:04 <-- 200 https://production.cloudflare.docker.com/registry-v2/docker/registry/v2/blobs/sha256/85/85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95/data?verify=1676657884-FcRw%2BcmVyS9UfSxcXpA5zXcpY2A%3D (44.011799ms)
2023/02/17 09:28:04 HTTP/2.0 200 OK
Content-Length: 247
Accept-Ranges: bytes
Age: 0
Cache-Control: public, max-age=14400
Cf-Cache-Status: HIT
Cf-Ray: 79b03cc6586c97f7-SJC
Content-Type: application/octet-stream
Date: Fri, 17 Feb 2023 17:28:04 GMT
Etag: "e52091fe9a6df3f9cb034e61f2e4a7dd"
Expires: Fri, 17 Feb 2023 21:28:04 GMT
Last-Modified: Fri, 17 Feb 2023 17:25:36 GMT
Server: cloudflare
Vary: Accept-Encoding
X-Amz-Id-2: md3LpfFBwzhgz7CrlehH2mrWlIfmZiZuK0gAtUvB0l3ATUq9vXzIfx52ly2ycAnO2iPk3Kp5xEM=
X-Amz-Request-Id: W2G81PPSF4QS3B2A
X-Amz-Version-Id: irnkL89fqEtE64wLeU6wjuDz2yuRewUj


2023/02/17 09:28:04 --> PUT https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig
2023/02/17 09:28:04 PUT /v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig HTTP/1.1
Host: index.docker.io
User-Agent: cosign/v1.13.1 (linux; amd64) go-containerregistry/v0.11.0
Content-Length: 558
Authorization: <redacted>
Content-Type: application/vnd.oci.image.manifest.v1+json
Accept-Encoding: gzip

{"schemaVersion":2,"mediaType":"application/vnd.oci.image.manifest.v1+json","config":{"mediaType":"application/vnd.oci.image.config.v1+json","size":247,"digest":"sha256:85ad8e17d3d7c00664855c638832bd99f32d42542c2d587851410a45a7f60b95"},"layers":[{"mediaType":"application/vnd.dev.cosign.simplesigning.v1+json","size":252,"digest":"sha256:b671489ededd1a180bd87235bba00fd83354f9c7d13b71d9f8b66a8e52965ebc","annotations":{"dev.cosignproject.cosign/signature":"MEYCIQCPH7NJAIfrB6BZN91dV0o7l/i11muXrvrAh100jDMMhAIhAPsLH0oXb2OPITXRpWBMUd3vHtz5Ks5pql2Hr6t/IJXw"}}]}
2023/02/17 09:28:05 <-- 201 https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256-4c1c50d0ffc614f90b93b07d778028dc765548e823f676fb027f61d281ac380d.sig (173.393947ms)
2023/02/17 09:28:05 HTTP/1.1 201 Created
Content-Length: 0
Date: Fri, 17 Feb 2023 17:28:05 GMT
Docker-Content-Digest: sha256:7ebe8964225fa4619b53aa35416ef0246c037e36ddf81776b21b15e1dda2262b
Docker-Distribution-Api-Version: registry/2.0
Docker-Ratelimit-Source: 91.193.113.196
Location: https://index.docker.io/v2/chihjenhuang/cosign1/manifests/sha256:7ebe8964225fa4619b53aa35416ef0246c037e36ddf81776b21b15e1dda2262b
Strict-Transport-Security: max-age=31536000
```