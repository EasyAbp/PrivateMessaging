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

namespace EasyAbp.PrivateMessaging.AuthDemo;

[DependsOn(typeof(AuthDemoDomainModule))]
[DependsOn(typeof(AuthDemoApplicationContractsModule))]

[DependsOn(typeof(AbpAccountApplicationModule))]
[DependsOn(typeof(AbpIdentityApplicationModule))]
[DependsOn(typeof(AbpPermissionManagementApplicationModule))]
[DependsOn(typeof(AbpTenantManagementApplicationModule))]
[DependsOn(typeof(AbpFeatureManagementApplicationModule))]
[DependsOn(typeof(AbpSettingManagementApplicationModule))]
//app modules
public class AuthDemoApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AuthDemoApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AuthDemoApplicationModule>();
        });
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<AuthDemoApplicationAutoMapperProfile>(validate: true);
        });
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AuthDemoApplicationModule>();
        });
    }
}
