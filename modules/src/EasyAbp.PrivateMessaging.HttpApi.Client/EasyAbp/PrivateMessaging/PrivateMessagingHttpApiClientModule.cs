using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.PrivateMessaging
{
    [DependsOn(
        typeof(PrivateMessagingApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class PrivateMessagingHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = PrivateMessagingRemoteServiceConsts.RemoteServiceName;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(PrivateMessagingApplicationContractsModule).Assembly,
                RemoteServiceName
            );
            
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<PrivateMessagingApplicationContractsModule>();
            });
        }
    }
}
