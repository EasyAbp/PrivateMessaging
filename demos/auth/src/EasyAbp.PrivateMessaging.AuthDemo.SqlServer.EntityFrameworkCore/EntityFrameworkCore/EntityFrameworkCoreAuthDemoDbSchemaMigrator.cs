using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;
using System;
using EasyAbp.PrivateMessaging.AuthDemo.Data;

namespace EasyAbp.PrivateMessaging.AuthDemo.SqlServer.EntityFrameworkCore;

public class EntityFrameworkCoreAuthDemoDbSchemaMigrator(
    IServiceProvider serviceProvider)
        : IAuthDemoDbSchemaMigrator, ITransientDependency
{
    public async Task MigrateAsync()
    {
        /* We intentionally resolving the LayoutMigrationsDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await serviceProvider
            .GetRequiredService<AuthDemoMigrationsDbContext>()
            .Database
            .MigrateAsync();
    }
}