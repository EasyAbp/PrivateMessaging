using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;
using System;
using EasyAbp.PrivateMessaging.MainDemo.Data;

namespace EasyAbp.PrivateMessaging.MainDemo.SqlServer.EntityFrameworkCore;

public class EntityFrameworkCoreMainDemoDbSchemaMigrator(
    IServiceProvider serviceProvider)
        : IMainDemoDbSchemaMigrator, ITransientDependency
{
    public async Task MigrateAsync()
    {
        /* We intentionally resolving the LayoutMigrationsDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await serviceProvider
            .GetRequiredService<MainDemoMigrationsDbContext>()
            .Database
            .MigrateAsync();
    }
}