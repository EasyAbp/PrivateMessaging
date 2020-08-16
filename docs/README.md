# PrivateMessaging

[![NuGet](https://img.shields.io/nuget/v/EasyAbp.PrivateMessaging.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.PrivateMessaging.Domain.Shared)
[![NuGet Download](https://img.shields.io/nuget/dt/EasyAbp.PrivateMessaging.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.PrivateMessaging.Domain.Shared)

An abp application module that allows users to send private messages to each other.

The online preview： https://pm.samples.easyabp.io

## Getting Started

* Install with [AbpHelper](https://github.com/EasyAbp/AbpHelper.GUI)

    Coming soon.

* Install Manually

    1. Install `EasyAbp.PrivateMessaging.Application` NuGet package to `MyProject.Application` project and add `[DependsOn(PrivateMessagingApplicationModule)]` attribute to the module.

    1. Install `EasyAbp.PrivateMessaging.Application.Contracts` NuGet package to `MyProject.Application.Contracts` project and add `[DependsOn(PrivateMessagingApplicationContractsModule)]` attribute to the module.

    1. Install `EasyAbp.PrivateMessaging.Domain` NuGet package to `MyProject.Domain` project and add `[DependsOn(PrivateMessagingDomainModule)]` attribute to the module.

    1. Install `EasyAbp.PrivateMessaging.Domain.Shared` NuGet package to `MyProject.Domain.Shared` project and add `[DependsOn(PrivateMessagingDomainSharedModule)]` attribute to the module.

    1. Install `EasyAbp.PrivateMessaging.EntityFrameworkCore` NuGet package to `MyProject.EntityFrameworkCore` project and add `[DependsOn(PrivateMessagingEntityFrameworkCoreModule)]` attribute to the module.

    1. Install `EasyAbp.PrivateMessaging.HttpApi` NuGet package to `MyProject.HttpApi` project and add `[DependsOn(PrivateMessagingHttpApiModule)]` attribute to the module.

    1. Install `EasyAbp.PrivateMessaging.HttpApi.Client` NuGet package to `MyProject.HttpApi.Client` project and add `[DependsOn(PrivateMessagingHttpApiClientModule)]` attribute to the module.

    1. Install `EasyAbp.PrivateMessaging.MongoDB` NuGet package to `MyProject.MongoDB` project and add `[DependsOn(PrivateMessagingMongoDbModule)]` attribute to the module.

    1. (Optional) If you need MVC UI, install `EasyAbp.PrivateMessaging.Web` NuGet package to `MyProject.Web` project and add `[DependsOn(PrivateMessagingWebModule)]` attribute to the module.

    1. Add `builder.ConfigurePrivateMessaging();` to OnModelCreating method in `MyProjectMigrationsDbContext.cs`.

    1. Add EF Core migrations and update your database. See: [ABP document](https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=MVC#add-new-migration-update-the-database).

## Usage

1. Add permissions to the roles you want.

1. Enjoy this wonderful module.

![Notifications](/docs/images/Notifications.png)
![Write a message](/docs/images/WriteMessage.png)
![Inbox](/docs/images/Inbox.png)
![Read a message](/docs/images/ReadMessage.png)

## Roadmap

- [ ] Add more setting items.
- [ ] Add MongoDB notification implementation.
- [ ] Unit tests.
