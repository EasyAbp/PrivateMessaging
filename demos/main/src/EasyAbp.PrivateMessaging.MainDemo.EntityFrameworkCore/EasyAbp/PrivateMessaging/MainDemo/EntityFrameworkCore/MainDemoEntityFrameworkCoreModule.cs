using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using EasyAbp.PrivateMessaging.EntityFrameworkCore;

namespace EasyAbp.PrivateMessaging.MainDemo.EntityFrameworkCore;

[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpIdentityEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpPermissionManagementEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpSettingManagementEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpAuditLoggingEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpTenantManagementEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpFeatureManagementEntityFrameworkCoreModule))]
//app modules
[DependsOn(typeof(MainDemoDomainModule))]
[DependsOn(typeof(PrivateMessagingEntityFrameworkCoreModule))]
public class MainDemoEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        MainDemoEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<MainDemoDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also LayoutMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer(x => x.UseCompatibilityLevel(120));
        });
    }
}
