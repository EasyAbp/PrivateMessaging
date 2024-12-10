using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.PrivateMessaging;

namespace EasyAbp.PrivateMessaging.UnifiedDemo.EntityFrameworkCore
{
    [ConnectionStringName(PrivateMessagingDbProperties.ConnectionStringName)]
    public interface IUnifiedDemoDbContext : IEfCoreDbContext
    {
    }
}
