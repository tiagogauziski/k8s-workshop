# Getting started

Before we can move on, we need to download `kubectl` binaries and deploy it on a local folder somewhere.

## Download
Download the latest release of `kubectl` for `windows`/`amd64`. 

For simplity, you can use copy this one and add your browser:
https://dl.k8s.io/v1.33.3/bin/windows/amd64/kubelet.exe

## Install
We just need to place the `kubectl` command line tool on a folder somewhere.

As an example, I'll create a folder under `C:\Temp\kubectl` path and place the executable there. It should look like this:
```
PS C:\Temp\kubectl> dir


    Directory: C:\Temp\kubectl


Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a----        16/08/2025   2:52 pm       61709824 kubectl.exe
```

## Open PowerShell

In order to simplify our commands, we need to set an PowerShell alias

```pwsh
Set-Alias -Name kubectl -Value .\kubectl.exe
```

## Verify client
To make sure we can execute `kubectl`, lets try to get the binary version:

```pwsh
kubectl version --client

# Output
# Client Version: v1.33.3
# Kustomize Version: v5.6.0
```

## Set KUBECONFIG environment variable
We will have to override this environment variable, to make sure we don't conflict with an existing Kubernetes installation:
```pwsh
$env:KUBECONFIG=".\config"
```

## Verify server
We can now verify the server version:
```pwsh
kubectl version --client

# Output
# Client Version: v1.33.3
# Kustomize Version: v5.6.0
# Server Version: v1.32.5
```