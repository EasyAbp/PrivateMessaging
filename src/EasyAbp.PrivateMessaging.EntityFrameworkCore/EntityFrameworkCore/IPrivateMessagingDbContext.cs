using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.PrivateMessaging.EntityFrameworkCore
{
    [ConnectionStringName(PrivateMessagingDbProperties.ConnectionStringName)]
    public interface IPrivateMessagingDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}