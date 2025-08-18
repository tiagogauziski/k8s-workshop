# Use the official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build --configuration Release
RUN dotnet publish --configuration Release --output /app/publish

# Use the official .NET runtime image for test execution
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS test
WORKDIR /app
COPY --from=build /app/publish .

# Run tests
CMD ["dotnet", "test", "K8sWorkshopTestProject.dll"]
