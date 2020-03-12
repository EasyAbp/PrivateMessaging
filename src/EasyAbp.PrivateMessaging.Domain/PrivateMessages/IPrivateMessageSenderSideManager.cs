using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public interface IPrivateMessageSenderSideManager : IDomainService
    {
        Task<long> CountAsync(Guid userId);
        
        Task<IReadOnlyList<PrivateMessage>>
            GetListAsync(Guid userId, int skipCount, int maxResultCount);

        Task<PrivateMessage> CreateAsync(PrivateMessage privateMessage);
    }
}