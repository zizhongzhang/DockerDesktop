# exit when any command fails
set -e

dockercli -SwitchLinuxEngine
# docker build -t dev/apicore:latest -f ./API.Core/Dockerfile .
docker run --rm -d -p 5001:80 -e ASPNETCORE_ENVIRONMENT=Development dev/apicore:latest

dockercli -SwitchWindowsEngine
# docker build -t dev/webframework:latest --build-arg source=./Web.Framework/obj/Docker/publish  --network "Default Switch" -f ./Web.Framework/Dockerfile .
docker run --rm -d -p 5000:80 dev/webframework:latest
