using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging
{
    [DependsOn(
        typeof(PrivateMessagingHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class PrivateMessagingConsoleApiClientModule : AbpModule
    {
        
    }
}
