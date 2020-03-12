using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public interface IPrivateMessageNotificationManager : IDomainService
    {
        Task<IReadOnlyList<PrivateMessageNotification>> GetListAsync(Guid userId, int skipCount, int maxResultCount);

        Task<PrivateMessageNotification> CreateAsync(PrivateMessageNotification notification);
        
        Task DeleteAsync(PrivateMessageNotification notification);

        Task DeleteByPrivateMessageIdAsync(Guid privateMessageId);
    }
}