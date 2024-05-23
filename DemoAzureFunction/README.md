# Publishing azure function as a container without dockerfile
this is unfortunately **not yet supported** by the Azure Functions runtime. You can only publish a function as a container if you have a Dockerfile.
You can follow the official issue [here](https://github.com/Azure/azure-functions-core-tools/issues/3355) and [here](https://github.com/dotnet/sdk-container-builds/issues/411) for updates.

I'll leave the code in here for future testing if there is ever an update but the request is open since april 2023 and they would include it in the release of june 2023. So i'm not very hopeful for a quick addition.