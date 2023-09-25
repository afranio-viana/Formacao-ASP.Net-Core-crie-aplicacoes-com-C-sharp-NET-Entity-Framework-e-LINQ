# Use the SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /App

# Copy csproj files and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Install EF Core CLI
RUN dotnet new tool-manifest
RUN dotnet tool install --global dotnet-ef --version 7.0.0-*
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copy the rest of the application
COPY . .

# Build and publish a release
RUN dotnet publish -c Release -o /publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "GerenciadorDeTarefaApi.dll"]