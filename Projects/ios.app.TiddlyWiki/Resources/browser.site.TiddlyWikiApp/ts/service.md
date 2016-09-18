

Environment
===========


```
export PORT=4200
export HOST=127.0.0.1
```


TiddlyWikiRepository
====================


ping
----

```
curl -d '["request",{},"TiddlyWikiRepository",1,0,"ping",{}]' http://$HOST:$PORT/services
```
