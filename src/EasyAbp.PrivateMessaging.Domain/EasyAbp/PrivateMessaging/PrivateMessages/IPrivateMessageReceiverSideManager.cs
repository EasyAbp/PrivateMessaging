﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public interface IPrivateMessageReceiverSideManager : IDomainService
    {
        Task SetReadAsync(PrivateMessage privateMessage);
        
        Task<long> CountAsync(Guid userId, bool unreadOnly = false, string category = null);

        Task<IReadOnlyList<PrivateMessage>> GetListAsync(Guid userId, int skipCount, int maxResultCount,
            bool unreadOnly = false, string category = null);

        Task DeleteAsync(PrivateMessage privateMessage);
    }
}