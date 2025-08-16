# Exposing a `Deployment` using a `Service`

Previously we used `kubectl port-forward` to access our service, but there is a better way of exposing an application: `Service`.

## Create a `Service` manifest
Let's create a `Service` manifest file in our folder (let's name it `service.yaml`):
```yaml
apiVersion: v1
kind: Service
metadata:
  name: tiago
  namespace: tiago
spec:
  type: LoadBalancer
  selector:
    app: nginx
  ports:
    - protocol: TCP
      port: 80
      targetPort: 80
```
> Reference: https://kubernetes.io/docs/concepts/services-networking/service/

# Apply the manifest
Let's apply the manifest:
```pwsh
kubectl apply -f . -n tiago

# Output
# deployment.apps/tiago created
# pod/tiago unchanged
# service/tiago created
```

Let's have a look at the `Service` we just created:
```pwsh
kubectl get service -n tiago

# Output
# NAME    TYPE           CLUSTER-IP   EXTERNAL-IP      PORT(S)        AGE
# tiago   LoadBalancer   10.0.16.2    172.204.41.183   80:32345/TCP   8m45s
```

You may have noticed we have an value on the `EXTERNAL-IP` column. If you open that IP address on your browser, you should be able to access the service:
```
Welcome to nginx!
If you see this page, the nginx web server is successfully installed and working. Further configuration is required.

For online documentation and support please refer to nginx.org.
Commercial support is available at nginx.com.

Thank you for using nginx.
```