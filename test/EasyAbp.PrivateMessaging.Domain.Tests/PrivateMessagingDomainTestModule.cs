using EasyAbp.PrivateMessaging.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(PrivateMessagingEntityFrameworkCoreTestModule)
        )]
    public class PrivateMessagingDomainTestModule : AbpModule
    {
        
    }
}
