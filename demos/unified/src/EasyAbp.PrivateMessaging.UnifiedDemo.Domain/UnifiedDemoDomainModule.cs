using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.AuditLogging;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Identity;
using EasyAbp.PrivateMessaging.UnifiedDemo.MultiTenancy;
using Volo.Abp.IdentityServer;
using Volo.Abp.PermissionManagement.IdentityServer;

namespace EasyAbp.PrivateMessaging.UnifiedDemo;

[DependsOn(typeof(AbpEmailingModule))]
[DependsOn(typeof(AbpAuditLoggingDomainModule))]
[DependsOn(typeof(AbpFeatureManagementDomainModule))]
[DependsOn(typeof(AbpIdentityDomainModule))]
[DependsOn(typeof(AbpIdentityServerDomainModule))]
[DependsOn(typeof(AbpPermissionManagementDomainModule))]
[DependsOn(typeof(AbpPermissionManagementDomainIdentityServerModule))]
[DependsOn(typeof(AbpPermissionManagementDomainIdentityModule))]
[DependsOn(typeof(AbpSettingManagementDomainModule))]
[DependsOn(typeof(AbpTenantManagementDomainModule))]
//app modules
[DependsOn(typeof(UnifiedDemoDomainSharedModule))]
public class UnifiedDemoDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italian"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português (Brasil)"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
        });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

#if DEBUG
        context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
}
