# Demo
This is a project to demo the containzerization of a .NET api project. the API itself is just the default weatherforecast API that is created when you create a new .NET API project. The API is containerized and run in docker desktop.
let's go over the TestAPI/TestAPI.csproj file:
```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <PublishProfile>DefaultContainer</PublishProfile>
    <ContainerRepository>WebAPIDemo</ContainerRepository>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
  </ItemGroup>

</Project>
```
note here the publish profile is set to DefaultContainer and the ContainerRepository is set to WebAPIDemo. The publish profile is used to publish the API to a container and the ContainerRepository is the name of the repository where the container image will be pushed to. The container image will be tagged with the version number of the API. The API is published to a container by running the following command:
```bash
dotnet publish
```
There is nothing more to this.
## DevOps
in the [pipeline](../azure-pipelines.yml) we have both a basic and advanced publish setup:
```yaml
- task: DotNetCoreCLI@2
  displayName: 'Basic Publish TestAPI'
  inputs:
    projects: 'TestAPI/TestAPI.csproj'
    command: 'publish'
    publishWebProjects: false
    arguments: '-p ContainerRegistry=myblogcontainerizedemo.azurecr.io'
    zipAfterPublish: false

- task: DotNetCoreCLI@2
  displayName: 'Advanced Publish TestAPI'
  inputs:
    projects: 'TestAPI/TestAPI.csproj'
    command: 'publish'
    publishWebProjects: false
    arguments: >-
        -p PublishProfile="DefaultContainer"
        -p ContainerRepository="testapiAlpine"
        -p ContainerImageTags="\"1.0.0;latest\""
        -p Version="1.0.0.0"
        -p ContainerRegistry="myblogcontainerizedemo.azurecr.io"
        -p ContainerUser="root"
        -p ContainerFamily="alpine"
        -p ContainerRuntimeIdentifier="linux-x64"
    zipAfterPublish: false
```