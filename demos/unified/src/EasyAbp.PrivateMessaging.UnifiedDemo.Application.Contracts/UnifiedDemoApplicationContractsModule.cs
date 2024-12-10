using EasyAbp.PrivateMessaging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace EasyAbp.PrivateMessaging.UnifiedDemo;

[DependsOn(typeof(AbpObjectExtendingModule))]
[DependsOn(typeof(AbpAccountApplicationContractsModule))]
[DependsOn(typeof(AbpFeatureManagementApplicationContractsModule))]
[DependsOn(typeof(AbpIdentityApplicationContractsModule))]
[DependsOn(typeof(AbpPermissionManagementApplicationContractsModule))]
[DependsOn(typeof(AbpSettingManagementApplicationContractsModule))]
[DependsOn(typeof(AbpTenantManagementApplicationContractsModule))]
//app modules
[DependsOn(typeof(UnifiedDemoDomainSharedModule))]

[DependsOn(typeof(PrivateMessagingApplicationContractsModule))]
public class UnifiedDemoApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        UnifiedDemoDtoExtensions.Configure();
    }
}
