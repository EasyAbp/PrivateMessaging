using EasyAbp.PrivateMessaging.UnifiedDemo;
using EasyAbp.PrivateMessaging.UnifiedDemo.SqlServer.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging.UnifiedDemo.DbMigrator;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(UnifiedDemoEntityFrameworkCoreSqlServerModule))]
[DependsOn(typeof(UnifiedDemoApplicationContractsModule))]
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
