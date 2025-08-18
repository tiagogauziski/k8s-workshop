# Use the official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build --configuration Release

# Use the official .NET runtime image for test execution
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS test
WORKDIR /app
COPY --from=build /app .

# Run tests
CMD ["dotnet", "test", "K8sWorkshopTestProject.dll"]
