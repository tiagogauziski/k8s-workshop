# Running a `Job`

So far we explored `Pod`, `Deployment` and `Services`. They are Kubernetes concepts useful for running applications that should run continuously (like a web application).

What if you need to execute an short lived task? Like a system test?

For that we have Kubernetes `Job` object.

## Create a `Job` manifest
Let's create a `Job` manifest file (let's name it `job.yaml`):
```yaml
apiVersion: batch/v1
kind: Job
metadata:
  name: my-job
  namespace: tiago
spec:
  activeDeadlineSeconds: 180
  ttlSecondsAfterFinished: 180
  backoffLimit: 0
  template:
    spec:
      containers:
      - name: tests
        image: ghcr.io/tiagogauziski/k8s-workshop/k8s-workshop-test-project:latest
        command: ["dotnet",  "test"]
        env:
        - name: TEST_ENDPOINT
          value: "http://my-service.tiago.svc.cluster.local:80/" # <service-name>.<namespace>.svc.cluster.local
      restartPolicy: Never
```
> Reference: https://kubernetes.io/docs/concepts/workloads/controllers/job/

# Apply the manifest
Let's apply the manifest:
```pwsh
kubectl apply -f . -n tiago

# Output
# deployment.apps/my-deployment unchanged
# job.batch/my-job created
# pod/my-pod unchanged
# service/my-service unchanged
```