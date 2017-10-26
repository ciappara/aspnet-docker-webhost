::dotnet publish -r debian.8-x64
dotnet publish "..\aspnet-docker-webhost\aspnet-docker-webhost.csproj" -r debian.8-x64
XCOPY "../aspnet-docker-webhost/bin/Debug/netcoreapp2.0/debian.8-x64/publish" aspnet-docker-webhost /S /Y /I
docker build --build-arg EXE_DIR=./aspnet-docker-webhost -t localhost:5000/aspnet-docker-webhost:latest .
docker push localhost:5000/aspnet-docker-webhost
runimage.cmd