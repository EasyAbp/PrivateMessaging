using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace EasyAbp.PrivateMessaging
{
    [DependsOn(
        typeof(PrivateMessagingDomainModule),
        typeof(PrivateMessagingApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class PrivateMessagingApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<PrivateMessagingApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<PrivateMessagingApplicationModule>(validate: true);
            });
        }
    }
}
