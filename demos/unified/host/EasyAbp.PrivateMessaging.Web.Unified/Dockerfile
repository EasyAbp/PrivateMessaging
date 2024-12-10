#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["host/EasyAbp.PrivateMessaging.Web.Unified/EasyAbp.PrivateMessaging.Web.Unified.csproj", "host/EasyAbp.PrivateMessaging.Web.Unified/"]
COPY ["src/EasyAbp.PrivateMessaging.Web/EasyAbp.PrivateMessaging.Web.csproj", "src/EasyAbp.PrivateMessaging.Web/"]
COPY ["src/EasyAbp.PrivateMessaging.HttpApi/EasyAbp.PrivateMessaging.HttpApi.csproj", "src/EasyAbp.PrivateMessaging.HttpApi/"]
COPY ["src/EasyAbp.PrivateMessaging.Application.Contracts/EasyAbp.PrivateMessaging.Application.Contracts.csproj", "src/EasyAbp.PrivateMessaging.Application.Contracts/"]
COPY ["src/EasyAbp.PrivateMessaging.Domain.Shared/EasyAbp.PrivateMessaging.Domain.Shared.csproj", "src/EasyAbp.PrivateMessaging.Domain.Shared/"]
COPY ["src/EasyAbp.PrivateMessaging.Application/EasyAbp.PrivateMessaging.Application.csproj", "src/EasyAbp.PrivateMessaging.Application/"]
COPY ["src/EasyAbp.PrivateMessaging.Domain/EasyAbp.PrivateMessaging.Domain.csproj", "src/EasyAbp.PrivateMessaging.Domain/"]
COPY ["src/EasyAbp.PrivateMessaging.EntityFrameworkCore/EasyAbp.PrivateMessaging.EntityFrameworkCore.csproj", "src/EasyAbp.PrivateMessaging.EntityFrameworkCore/"]
COPY ["host/EasyAbp.PrivateMessaging.Host.Shared/EasyAbp.PrivateMessaging.Host.Shared.csproj", "host/EasyAbp.PrivateMessaging.Host.Shared/"]
COPY Directory.Build.props .
RUN dotnet restore "host/EasyAbp.PrivateMessaging.Web.Unified/EasyAbp.PrivateMessaging.Web.Unified.csproj"
COPY . .
WORKDIR "/src/host/EasyAbp.PrivateMessaging.Web.Unified"
RUN dotnet build "EasyAbp.PrivateMessaging.Web.Unified.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyAbp.PrivateMessaging.Web.Unified.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyAbp.PrivateMessaging.Web.Unified.dll"]