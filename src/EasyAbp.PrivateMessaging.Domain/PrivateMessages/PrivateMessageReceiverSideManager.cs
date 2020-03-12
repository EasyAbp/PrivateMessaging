using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications;
using Volo.Abp.Domain.Services;
using Volo.Abp.Timing;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class PrivateMessageReceiverSideManager : DomainService, IPrivateMessageReceiverSideManager
    {
        private readonly IClock _clock;
        private readonly IPrivateMessageNotificationManager _privateMessageNotificationManager;
        private readonly IPrivateMessageRepository _repository;

        public PrivateMessageReceiverSideManager(
            IClock clock,
            IPrivateMessageNotificationManager privateMessageNotificationManager,
            IPrivateMessageRepository repository)
        {
            _clock = clock;
            _privateMessageNotificationManager = privateMessageNotificationManager;
            _repository = repository;
        }
        
        public async Task SetReadAsync(PrivateMessage privateMessage)
        {
            privateMessage.TrySetReadTime(_clock.Now);

            await _repository.UpdateAsync(privateMessage, true);
        }

        public async Task<long> CountAsync(Guid userId, bool unreadOnly = false)
        {
            return await _repository.CountReceivingAsync(userId, unreadOnly);
        }

        public async Task<IReadOnlyList<PrivateMessage>> GetListAsync(Guid userId, int skipCount,
            int maxResultCount, bool unreadOnly = false)
        {
            return await _repository.GetListReceivingAsync(userId, skipCount, maxResultCount, unreadOnly);
        }

        public async Task DeleteAsync(PrivateMessage privateMessage)
        {
            await _privateMessageNotificationManager.DeleteByPrivateMessageIdAsync(privateMessage.Id);
            
            await _repository.DeleteAsync(privateMessage, true);
        }
    }
}