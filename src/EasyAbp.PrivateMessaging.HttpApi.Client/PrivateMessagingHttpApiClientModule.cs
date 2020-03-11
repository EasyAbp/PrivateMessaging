using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging
{
    [DependsOn(
        typeof(PrivateMessagingApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class PrivateMessagingHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "PrivateMessaging";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(PrivateMessagingApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
