# Declarative commands

## `kubectl apply`

We have experimented with `kubectl run`, but running imperative commands on real clusters don't make much sense. 

Kubernetes offer us an alternative: declaring a manifest file with what you want deployed and then Kubernetes to apply it for you.

So now, we need to create a file named `pod.yaml` and write the following contents:
```yaml
apiVersion: v1
kind: Pod
metadata:
  name: tiago
  namespace: tiago
spec:
  containers:
  - name: nginx
    image: nginx
    ports:
    - containerPort: 80
```
> Reference: https://kubernetes.io/docs/concepts/workloads/pods/

Once we have a manifest of what our `Pod` should look like, lets apply to the cluster:
```pwsh
# We are using "." to tell kubectl apply anything that ends with ".yaml" to the cluster
kubectl apply -f .
```

You may have noticed, we have got an error:
```
Error from server (NotFound): error when creating "pod.yaml": namespaces "tiago" not found
```

## `kubectl create namespace`
Namespaces are a "logical" separator in Kubernetes and it's useful to separate workloads or even tenants in logical containers.

We will create a namespace for us:
```pwsh
kubectl create namespace tiago

# Output
# namespace/tiago created
```

## `kubectl apply` (continued)
Let's try again now:
```pwsh
kubectl apply -f .

# Output
# pod/nginx created
```

Great, we have our `Pod` created via our manifest file. Lets have a look:
```pwsh
# As our resource has been created in a specific namespace
# We now need to list the resources from our namespace tiago
kubectl get pods -n tiago

# Output
# NAME    READY   STATUS    RESTARTS   AGE
# nginx   1/1     Running   0          5m29s
```