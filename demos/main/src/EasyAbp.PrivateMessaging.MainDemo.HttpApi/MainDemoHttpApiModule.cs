using EasyAbp.PrivateMessaging.MainDemo.Localization;
using EasyAbp.PrivateMessaging;
using Localization.Resources.AbpUi;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace EasyAbp.PrivateMessaging.MainDemo;

[DependsOn(typeof(MainDemoApplicationContractsModule))]
[DependsOn(typeof(AbpAccountHttpApiModule))]
[DependsOn(typeof(AbpIdentityHttpApiModule))]
[DependsOn(typeof(AbpPermissionManagementHttpApiModule))]
[DependsOn(typeof(AbpTenantManagementHttpApiModule))]
[DependsOn(typeof(AbpFeatureManagementHttpApiModule))]
[DependsOn(typeof(AbpSettingManagementHttpApiModule))]
//app modules
[DependsOn(typeof(PrivateMessagingHttpApiModule))]
public class MainDemoHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<MainDemoResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
