using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public interface IPrivateMessageRepository : IRepository<PrivateMessage, Guid>
    {
        Task<IReadOnlyList<PrivateMessage>> GetListAsync(IEnumerable<Guid> ids, bool includeDetails = false,
            CancellationToken cancellationToken = default);

        Task<long> CountSendingAsync(Guid userId, bool unreadOnly = false,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<PrivateMessage>> GetListSendingAsync(Guid userId, int skipCount, int maxResultCount,
            bool unreadOnly = false, CancellationToken cancellationToken = default);

        Task<long> CountReceivingAsync(Guid userId, bool unreadOnly = false,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<PrivateMessage>> GetListReceivingAsync(Guid userId, int skipCount, int maxResultCount,
            bool unreadOnly = false, CancellationToken cancellationToken = default);
    }
}