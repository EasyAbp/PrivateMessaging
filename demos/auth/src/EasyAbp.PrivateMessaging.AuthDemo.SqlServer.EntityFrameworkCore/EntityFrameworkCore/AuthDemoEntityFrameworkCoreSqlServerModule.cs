using EasyAbp.PrivateMessaging.AuthDemo.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging.AuthDemo.SqlServer.EntityFrameworkCore;

[DependsOn(typeof(AuthDemoEntityFrameworkCoreModule))]
public class AuthDemoEntityFrameworkCoreSqlServerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AuthDemoMigrationsDbContext>();
    }
}