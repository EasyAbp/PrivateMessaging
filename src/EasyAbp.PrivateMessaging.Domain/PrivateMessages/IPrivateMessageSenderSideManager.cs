using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public interface IPrivateMessageSenderSideManager : IDomainService
    {
        Task<IReadOnlyList<PrivateMessage>> GetSentMessagesAsync(Guid userId, Guid? tenantId, int skipCount,
            int maxResultCount);
    }
}