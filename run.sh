# exit when any command fails
set -e

dockercli -SwitchLinuxEngine
docker run --rm -d -p 5001:80 -e ASPNETCORE_ENVIRONMENT=Development apicore/dev

dockercli -SwitchWindowsEngine
docker run --rm -d -p 5000:80 webframework/dev
