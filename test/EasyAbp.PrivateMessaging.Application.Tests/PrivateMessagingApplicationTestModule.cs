using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging
{
    [DependsOn(
        typeof(PrivateMessagingApplicationModule),
        typeof(PrivateMessagingDomainTestModule)
        )]
    public class PrivateMessagingApplicationTestModule : AbpModule
    {

    }
}
