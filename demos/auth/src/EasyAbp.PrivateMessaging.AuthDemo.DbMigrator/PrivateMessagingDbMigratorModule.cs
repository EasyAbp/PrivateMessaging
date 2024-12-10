using EasyAbp.PrivateMessaging.AuthDemo;
using EasyAbp.PrivateMessaging.AuthDemo.SqlServer.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging.AuthDemo.DbMigrator;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AuthDemoEntityFrameworkCoreSqlServerModule))]
[DependsOn(typeof(AuthDemoApplicationContractsModule))]
public class PrivateMessagingDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also LayoutMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer(x => x.UseCompatibilityLevel(120));
        });
    }
}
