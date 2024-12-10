using EasyAbp.PrivateMessaging;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace EasyAbp.PrivateMessaging.UnifiedDemo;

[DependsOn(typeof(UnifiedDemoDomainModule))]
[DependsOn(typeof(UnifiedDemoApplicationContractsModule))]

[DependsOn(typeof(AbpAccountApplicationModule))]
[DependsOn(typeof(AbpIdentityApplicationModule))]
[DependsOn(typeof(AbpPermissionManagementApplicationModule))]
[DependsOn(typeof(AbpTenantManagementApplicationModule))]
[DependsOn(typeof(AbpFeatureManagementApplicationModule))]
[DependsOn(typeof(AbpSettingManagementApplicationModule))]
//app modules
[DependsOn(typeof(PrivateMessagingApplicationModule))]
public class UnifiedDemoApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<UnifiedDemoApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<UnifiedDemoApplicationModule>();
        });
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<UnifiedDemoApplicationAutoMapperProfile>(validate: true);
        });
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<UnifiedDemoApplicationModule>();
        });
    }
}
