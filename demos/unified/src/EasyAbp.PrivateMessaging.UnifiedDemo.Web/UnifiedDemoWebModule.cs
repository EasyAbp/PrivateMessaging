using EasyAbp.PrivateMessaging.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Account.Web;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity.Web;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.TenantManagement.Web;
using EasyAbp.PrivateMessaging.UnifiedDemo;
using EasyAbp.PrivateMessaging.UnifiedDemo.Localization;

namespace EasyAbp.PrivateMessaging.UnifiedDemo.Web
{
    [DependsOn(typeof(UnifiedDemoApplicationContractsModule))]

    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]

    [DependsOn(typeof(AbpAccountWebModule))]
    [DependsOn(typeof(AbpIdentityWebModule))]
    [DependsOn(typeof(AbpAccountWebIdentityServerModule))]

    [DependsOn(typeof(AbpSettingManagementWebModule))]
    [DependsOn(typeof(AbpFeatureManagementWebModule))]
    [DependsOn(typeof(AbpTenantManagementWebModule))]

    [DependsOn(typeof(PrivateMessagingWebModule))]
    public class UnifiedDemoWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(UnifiedDemoResource), typeof(UnifiedDemoWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(UnifiedDemoWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<AbpNavigationOptions>(options =>
            //{
            //    options.MenuContributors.Add(new DemoMenuContributor());
            //});

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<UnifiedDemoWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<UnifiedDemoWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<UnifiedDemoWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });
        }
    }
}
