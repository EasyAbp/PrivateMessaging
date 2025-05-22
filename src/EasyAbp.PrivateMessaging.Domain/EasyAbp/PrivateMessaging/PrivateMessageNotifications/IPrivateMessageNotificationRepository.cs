using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public interface IPrivateMessageNotificationRepository : IRepository<PrivateMessageNotification, Guid>
    {
        Task<long> CountByUserIdAsync(Guid userId, string category = null, CancellationToken cancellationToken = default);
        
        Task<IReadOnlyList<PrivateMessageNotification>> GetListByUserIdAsync(Guid userId, int skipCount,
            int maxResultCount, string category = null, CancellationToken cancellationToken = default);

        Task DeleteByPrivateMessageIdAsync(IEnumerable<Guid> privateMessageIds,
            CancellationToken cancellationToken = default);
    }
}