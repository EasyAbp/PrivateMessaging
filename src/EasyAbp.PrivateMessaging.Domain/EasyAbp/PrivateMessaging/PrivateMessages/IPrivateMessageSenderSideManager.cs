using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public interface IPrivateMessageSenderSideManager : IDomainService
    {
        Task<long> CountAsync(Guid userId, string category = null);
        
        Task<IReadOnlyList<PrivateMessage>>
            GetListAsync(Guid userId, int skipCount, int maxResultCount, string category = null);

        Task<PrivateMessage> CreateAsync(
            [CanBeNull] IUserData fromUser,
            IUserData toUser,
            [NotNull] string title,
            [CanBeNull] string content,
            [CanBeNull] string category = null);
    }
}