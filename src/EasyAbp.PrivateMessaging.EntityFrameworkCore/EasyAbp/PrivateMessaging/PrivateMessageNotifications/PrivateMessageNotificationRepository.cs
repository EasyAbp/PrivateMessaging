using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public class PrivateMessageNotificationRepository :
        EfCoreRepository<IPrivateMessagingDbContext, PrivateMessageNotification, Guid>,
        IPrivateMessageNotificationRepository
    {
        public PrivateMessageNotificationRepository(IDbContextProvider<IPrivateMessagingDbContext> dbContextProvider) :
            base(dbContextProvider)
        {
        }

        public virtual async Task<long> CountByUserIdAsync(Guid userId, string category = null, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync()).Where(n => n.UserId == userId && n.Category == category).CountAsync(cancellationToken);
        }

        public virtual async Task<IReadOnlyList<PrivateMessageNotification>> GetListByUserIdAsync(Guid userId, int skipCount,
            int maxResultCount, string category = null, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .Where(n => n.UserId == userId && n.Category == category)
                .OrderByDescending(x => x.Id)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        public virtual async Task DeleteByPrivateMessageIdAsync(IEnumerable<Guid> privateMessageIds, CancellationToken cancellationToken = default)
        {
            await DeleteAsync(n => privateMessageIds.Contains(n.PrivateMessageId), true, cancellationToken);
        }
    }
}