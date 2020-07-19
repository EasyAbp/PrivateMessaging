using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Authorization;

namespace EasyAbp.PrivateMessaging
{
    [DependsOn(
        typeof(PrivateMessagingDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class PrivateMessagingApplicationContractsModule : AbpModule
    {

    }
}
