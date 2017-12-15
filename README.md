# aspnet-docker-webhost
Building an ASP.NET Core Docker image having WebHost


## How to run the aspnet-docker-webhost application?

Whilst in the csproj folder, run the following command to publish it for the debian runtime:

```
dotnet publish "..\aspnet-docker-webhost\aspnet-docker-webhost.csproj" -r debian.8-x64
```

Build and push the docker image:

```
docker build -t localhost:5000/aspnet-docker-webhost:latest .
docker push localhost:5000/aspnet-docker-webhost
```

If the docker image already exists, use the following command to delete the existing docker image:

```
docker rm -f aspnet-docker-webhost
```

Finally run the docker image, and you should be able to successfully run the webhost. By using the -p you can expose the port set in the UseUrls portion:

```
docker run -it -p 36098:36098 --name aspnet-docker-webhost localhost:5000/aspnet-docker-webhost
```