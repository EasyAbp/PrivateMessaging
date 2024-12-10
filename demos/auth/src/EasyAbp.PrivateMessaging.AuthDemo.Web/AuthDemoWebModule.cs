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
using EasyAbp.PrivateMessaging.AuthDemo.Localization;

namespace EasyAbp.PrivateMessaging.AuthDemo.Web
{
    [DependsOn(typeof(AuthDemoApplicationContractsModule))]

    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]

    [DependsOn(typeof(AbpAccountWebModule))]
    [DependsOn(typeof(AbpIdentityWebModule))]
    [DependsOn(typeof(AbpAccountWebIdentityServerModule))]

    [DependsOn(typeof(AbpSettingManagementWebModule))]
    [DependsOn(typeof(AbpFeatureManagementWebModule))]
    [DependsOn(typeof(AbpTenantManagementWebModule))]

    public class AuthDemoWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(AuthDemoResource), typeof(AuthDemoWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AuthDemoWebModule).Assembly);
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
                options.FileSets.AddEmbedded<AuthDemoWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<AuthDemoWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AuthDemoWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });
        }
    }
}
