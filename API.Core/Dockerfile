#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["API.Core/API.Core.csproj", "API.Core/"]
RUN dotnet restore "API.Core/API.Core.csproj"
COPY . .
WORKDIR "/src/API.Core"
RUN dotnet build "API.Core.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "API.Core.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Core.dll"]
