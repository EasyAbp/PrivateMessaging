using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public interface IPrivateMessageNotificationManager : IDomainService
    {
        Task<IReadOnlyList<PrivateMessageNotification>> GetNotificationsAsync(Guid userId, Guid? tenantId,
            int skipCount, int maxResultCount);

        Task ConsumeNotificationAsync(PrivateMessageNotification notification);
        
        Task ConsumeNotificationAsync(IEnumerable<PrivateMessageNotification> notifications);
    }
}