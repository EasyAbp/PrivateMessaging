using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.PrivateMessaging.PrivateMessages;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications;
using EasyAbp.PrivateMessaging.Users;

namespace EasyAbp.PrivateMessaging.EntityFrameworkCore
{
    [ConnectionStringName(PrivateMessagingDbProperties.ConnectionStringName)]
    public interface IPrivateMessagingDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<PrivateMessage> PrivateMessages { get; set; }
        DbSet<PrivateMessageNotification> PrivateMessageNotifications { get; set; }
        DbSet<PmUser> PmUser { get; set; }
    }
}
