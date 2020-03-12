using System;
using EasyAbp.PrivateMessaging.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public class PrivateMessageNotificationRepository : EfCoreRepository<PrivateMessagingDbContext, PrivateMessageNotification, Guid>, IPrivateMessageNotificationRepository
    {
        public PrivateMessageNotificationRepository(IDbContextProvider<PrivateMessagingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}