using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public class PrivateMessageNotificationManager : DomainService, IPrivateMessageNotificationManager
    {
        private readonly IPrivateMessageNotificationRepository _repository;

        public PrivateMessageNotificationManager(
            IPrivateMessageNotificationRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IReadOnlyList<PrivateMessageNotification>> GetListAsync(Guid userId, int skipCount, int maxResultCount)
        {
            return await _repository.GetListByUserIdAsync(userId, skipCount, maxResultCount);
        }

        public async Task<PrivateMessageNotification> CreateAsync(PrivateMessageNotification notification)
        {
            return await _repository.InsertAsync(notification, true);
        }

        public async Task DeleteAsync(PrivateMessageNotification notification)
        {
            await _repository.DeleteAsync(notification);
        }

        public async Task DeleteByPrivateMessageIdAsync(IEnumerable<Guid> privateMessageIds)
        {
            await _repository.DeleteByPrivateMessageIdAsync(privateMessageIds);
        }
    }
}