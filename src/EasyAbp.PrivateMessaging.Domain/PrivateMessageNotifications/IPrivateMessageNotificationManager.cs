using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public interface IPrivateMessageNotificationManager : IDomainService
    {
        Task<IReadOnlyList<PrivateMessageNotification>> GetAsync(Guid userId, Guid? tenantId, int skipCount,
            int maxResultCount);

        Task CreateAsync(PrivateMessageNotification notification);
        
        Task ConsumeAsync(PrivateMessageNotification notification);
        
        Task ConsumeAsync(IEnumerable<PrivateMessageNotification> notifications);
    }
}