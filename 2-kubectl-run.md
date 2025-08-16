# Imperative commands

## `kubectl run`  

If you ever executed a `docker run` command, `kubectl` will be as simple as that. 
This command would be probably the easiest one to get started with.

To get a template of what a `kubectl run` should look like, lets first call `kubectl run --help`:
```
Create and run a particular image in a pod.

Examples:
  # Start a nginx pod
  kubectl run nginx --image=nginx
...
```

We now have an example for us to use. Let's run it:
```pwsh
# Note that I've changed the pod name to a unique name.
kubectl run tiago --image=nginx

# Output
# pod/tiago created
```

There it go, the container has been created.

## `kubectl get pods`
In order to check the status of our pods, lets use `kubectl get pods` to list all available pods on the default namespace:
 Lets check it:
```pwsh
kubectl get pods
```

The output should be something like this:
```
NAME    READY   STATUS    RESTARTS   AGE
tiago   1/1     Running   0          7m56s
```

If we want to get additional information on the list, we can add the parameter `-o wide`:
```pwsh
kubectl get pods -o wide

# Output
# NAME    READY   STATUS    RESTARTS   AGE    IP            NODE                                NOMINATED NODE   READINESS GATES
# tiago   1/1     Running   0          8m1s   10.244.1.27   aks-agentpool-28619620-vmss000002   <none>           <none>
```

## `kubectl describe`

Running `kubectl get pods` is great, but it only give us table with only the relevant information. 

If you want to troubleshoot or deep dive into the running `Pod`, we can run:
```pwsh
kubectl describe pod nginx
```

You may notice a human description information about the `Pod`:
```
Name:             tiago
Namespace:        default
Priority:         0
Service Account:  default
Node:             aks-agentpool-28619620-vmss000002/10.224.0.5
Start Time:       Sat, 16 Aug 2025 16:25:04 +1200
Labels:           run=tiago
Annotations:      <none>
Status:           Running
IP:               10.244.1.110
IPs:
  IP:  10.244.1.110
Containers:
  tiago:
    Container ID:   containerd://4740d8be0047000dd1fb3b1c52a14e8e3ec23f68e2105d0f46fd7cb4d510c49f
    Image:          nginx
    Image ID:       docker.io/library/nginx@sha256:33e0bbc7ca9ecf108140af6288c7c9d1ecc77548cbfd3952fd8466a75edefe57
    Port:           <none>
    Host Port:      <none>
    State:          Running
      Started:      Sat, 16 Aug 2025 16:25:06 +1200
    Ready:          True
    Restart Count:  0
    Environment:    <none>
    Mounts:
      /var/run/secrets/kubernetes.io/serviceaccount from kube-api-access-f75dr (ro)
Conditions:
  Type                        Status
  PodReadyToStartContainers   True
  Initialized                 True
  Ready                       True
  ContainersReady             True
  PodScheduled                True
Volumes:
  kube-api-access-f75dr:
    Type:                    Projected (a volume that contains injected data from multiple sources)
    TokenExpirationSeconds:  3607
    ConfigMapName:           kube-root-ca.crt
    Optional:                false
    DownwardAPI:             true
QoS Class:                   BestEffort
Node-Selectors:              <none>
Tolerations:                 node.kubernetes.io/not-ready:NoExecute op=Exists for 300s
                             node.kubernetes.io/unreachable:NoExecute op=Exists for 300s
Events:
  Type    Reason     Age   From               Message
  ----    ------     ----  ----               -------
  Normal  Scheduled  35s   default-scheduler  Successfully assigned default/tiago to aks-agentpool-28619620-vmss000002
  Normal  Pulling    35s   kubelet            Pulling image "nginx"
  Normal  Pulled     33s   kubelet            Successfully pulled image "nginx" in 1.446s (1.446s including waiting). Image size: 72324501 bytes.
  Normal  Created    33s   kubelet            Created container: tiago
  Normal  Started    33s   kubelet            Started container tiago
```

## `kubectl port-forward`
We have deployed a container using `kubectl run` but how can we reach it?

We can use `kubectl port-forward` to redirect requests on a local port to reach our `Pod`:
```pwsh
kubectl port-forward tiago 1234:80

# Output
# Forwarding from 127.0.0.1:1234 -> 80
# Forwarding from [::1]:1234 -> 80
```

What is now happening is, the `kubectl` tool is listening on the port `1234` on your local machine, and forwarding it inside the cluster.

While the command is running, you can open your browser and access `http://localhost:1234/`, you should see the following page:
```
Welcome to nginx!
If you see this page, the nginx web server is successfully installed and working. Further configuration is required.

For online documentation and support please refer to nginx.org.
Commercial support is available at nginx.com.

Thank you for using nginx.
```