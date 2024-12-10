using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace EasyAbp.PrivateMessaging.AuthDemo;

[DependsOn(typeof(AuthDemoApplicationContractsModule))]
[DependsOn(typeof(AbpAccountHttpApiClientModule))]
[DependsOn(typeof(AbpIdentityHttpApiClientModule))]
[DependsOn(typeof(AbpPermissionManagementHttpApiClientModule))]
[DependsOn(typeof(AbpTenantManagementHttpApiClientModule))]
[DependsOn(typeof(AbpFeatureManagementHttpApiClientModule))]
[DependsOn(typeof(AbpSettingManagementHttpApiClientModule))]
//app modules
public class AuthDemoHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AuthDemoApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AuthDemoHttpApiClientModule>();
        });
    }
}
