# Deployment

We have now explored how to create a `Pod`, but how can we scale a `Pod`? We don't!

For stateless applications such as a web server, we should consider using a `Deployment` object, as it will give us additional tools to scale and maintain a service.

## Create a `Deployment` manifest
Let's create a `Deployment` manifest file in our folder (let's name it `deployment.yaml`):
```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: my-deployment
  namespace: tiago
  labels:
    app: nginx
spec:
  replicas: 3
  selector:
    matchLabels:
      app: nginx
  template:
    metadata:
      labels:
        app: nginx
    spec:
      containers:
      - name: nginx
        image: nginx:1.14.2
        ports:
        - containerPort: 80
```
> Reference: https://kubernetes.io/docs/concepts/workloads/controllers/deployment/

# Apply the manifest
Let's apply the manifest:
```pwsh
kubectl apply -f . -n tiago

# Output
# deployment.apps/my-deployment created
# pod/my-pod unchanged
```

Let's check the `Pod` created by the `Deployment`:
```pwsh
kubectl get pod -n tiago

# Output
# NAME                            READY   STATUS    RESTARTS   AGE
# my-pod                          1/1     Running   0          5m
# my-depoyment-647677fc66-5cnd4   1/1     Running   0          4m5s
# my-depoyment-647677fc66-mgxc5   1/1     Running   0          4m5s
# my-depoyment-647677fc66-pwf4q   1/1     Running   0          4m5s
```

You may note that we have additional pods, with the name of our deployment plus some additional values.

We can also check the `Deployment` status:
```pwsh
kubectl get deployments -n tiago

# Output
# kubectl get deployments -n tiago
# NAME            READY   UP-TO-DATE   AVAILABLE   AGE
# my-deployment   3/3     3            3           6m6s
```

