using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging
{
    [DependsOn(
        typeof(PrivateMessagingDomainSharedModule)
        )]
    public class PrivateMessagingDomainModule : AbpModule
    {

    }
}
