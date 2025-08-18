
# Use the official .NET SDK image for build and test
FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build --configuration Release
CMD ["dotnet", "test"]
