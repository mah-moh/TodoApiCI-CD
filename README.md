# TodoApi

info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\mahee\source\repos\TodoApi

```bash
curl -i localhost:5000/todos
```
```output
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Fri, 16 May 2025 16:02:38 GMT
Server: Kestrel
Transfer-Encoding: chunked
```

```bash
curl -i -X POST localhost:5000/todos -H "Content-Type: application/json" -d "{\"text\":\"Buy milk\"}"
```
```output
HTTP/1.1 201 Created
Content-Type: application/json; charset=utf-8
Date: Fri, 16 May 2025 16:06:54 GMT
Server: Kestrel
Location: /todos/6e657661-bfc1-4f7b-ad08-6f79689d231e
Transfer-Encoding: chunked
{"id":"6e657661-bfc1-4f7b-ad08-6f79689d231e","text":"Buy milk","isComplete":false,"createdAt":"2025-05-16T16:06:54.8147531Z"}
```

```bash
curl -i localhost:5000/todos/6e657661-bfc1-4f7b-ad08-6f79689d231e
```
```output
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Fri, 16 May 2025 16:09:03 GMT
Server: Kestrel
Transfer-Encoding: chunked
{"id":"6e657661-bfc1-4f7b-ad08-6f79689d231e","text":"Buy milk","isComplete":false,"createdAt":"2025-05-16T16:06:54.8147531Z"}
```

```bash
curl -i -X PUT localhost:5000/todos/6e657661-bfc1-4f7b-ad08-6f79689d231e -H "Content-Type: application/json" -d "{\"text\":\"Buy bread\",\"isComplete\":true}"
```
```output
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Fri, 16 May 2025 16:10:42 GMT
Server: Kestrel
Transfer-Encoding: chunked
{"id":"6e657661-bfc1-4f7b-ad08-6f79689d231e","text":"Buy bread","isComplete":true,"createdAt":"2025-05-16T16:06:54.8147531Z"}
```

```bash
curl -i -X DELETE localhost:5000/todos/6e657661-bfc1-4f7b-ad08-6f79689d231e
```
```output
HTTP/1.1 204 No Content
Date: Fri, 16 May 2025 16:11:56 GMT
Server: Kestrel
```
