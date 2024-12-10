using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using EasyAbp.PrivateMessaging.MainDemo.Localization;

namespace EasyAbp.PrivateMessaging.MainDemo;

[DependsOn(typeof(AbpAuditLoggingDomainSharedModule))]
[DependsOn(typeof(AbpFeatureManagementDomainSharedModule))]
[DependsOn(typeof(AbpIdentityDomainSharedModule))]
[DependsOn(typeof(AbpPermissionManagementDomainSharedModule))]
[DependsOn(typeof(AbpSettingManagementDomainSharedModule))]
[DependsOn(typeof(AbpTenantManagementDomainSharedModule))]
//app modules
[DependsOn(typeof(PrivateMessagingDomainSharedModule))]
public class MainDemoDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        MainDemoGlobalFeatureConfigurator.Configure();
        MainDemoModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MainDemoDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<MainDemoResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/MainDemo");

            options.DefaultResourceType = typeof(MainDemoResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("MainDemo", typeof(MainDemoResource));
        });
    }
}
