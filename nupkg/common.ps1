# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of projects
$projects = (

    "src/EasyAbp.PrivateMessaging.Application",
    "src/EasyAbp.PrivateMessaging.Application.Contracts",
    "src/EasyAbp.PrivateMessaging.Domain",
    "src/EasyAbp.PrivateMessaging.Domain.Shared",
    "src/EasyAbp.PrivateMessaging.EntityFrameworkCore",
    "src/EasyAbp.PrivateMessaging.HttpApi",
    "src/EasyAbp.PrivateMessaging.HttpApi.Client",
    "src/EasyAbp.PrivateMessaging.MongoDB",
    "src/EasyAbp.PrivateMessaging.Web"
)