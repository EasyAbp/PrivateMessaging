using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public interface IPrivateMessageReceiverSideManager : IDomainService
    {
        Task SetReadAsync(PrivateMessage privateMessage);
        
        Task SetReadAsync(IEnumerable<PrivateMessage> privateMessages);

        Task<IReadOnlyList<PrivateMessage>> GetUnreadMessagesAsync(Guid userId, Guid? tenantId, int skipCount,
            int maxResultCount);

        Task DeleteMessageAsync(PrivateMessage privateMessage);
    }
}