using Localization.Resources.AbpUi;
using EasyAbp.PrivateMessaging.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAbp.PrivateMessaging
{
    [DependsOn(
        typeof(PrivateMessagingApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class PrivateMessagingHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(PrivateMessagingHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<PrivateMessagingResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
