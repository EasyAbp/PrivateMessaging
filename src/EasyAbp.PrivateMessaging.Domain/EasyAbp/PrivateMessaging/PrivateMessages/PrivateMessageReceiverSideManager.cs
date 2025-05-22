using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Timing;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    [UnitOfWork]
    public class PrivateMessageReceiverSideManager : DomainService, IPrivateMessageReceiverSideManager
    {
        private readonly IClock _clock;
        private readonly IDistributedEventBus _distributedEventBus;
        private readonly IExternalUserLookupServiceProvider _externalUserLookupServiceProvider;
        private readonly IPrivateMessageNotificationRepository _privateMessageNotificationRepository;
        private readonly IPrivateMessageRepository _repository;

        public PrivateMessageReceiverSideManager(
            IClock clock,
            IDistributedEventBus distributedEventBus,
            IExternalUserLookupServiceProvider externalUserLookupServiceProvider,
            IPrivateMessageNotificationRepository privateMessageNotificationRepository,
            IPrivateMessageRepository repository)
        {
            _clock = clock;
            _distributedEventBus = distributedEventBus;
            _externalUserLookupServiceProvider = externalUserLookupServiceProvider;
            _privateMessageNotificationRepository = privateMessageNotificationRepository;
            _repository = repository;
        }

        public virtual async Task SetReadAsync(PrivateMessage privateMessage)
        {
            var fromUser = privateMessage.FromUserId.HasValue
                ? await _externalUserLookupServiceProvider.FindByIdAsync(privateMessage.FromUserId.Value)
                : null;

            var toUser = await _externalUserLookupServiceProvider.FindByIdAsync(privateMessage.ToUserId);

            await _privateMessageNotificationRepository.DeleteByPrivateMessageIdAsync(new[] { privateMessage.Id });

            privateMessage.TrySetReadTime(_clock.Now);

            await _repository.UpdateAsync(privateMessage, true);

            var eto = new PrivateMessageReadEto(privateMessage.TenantId, privateMessage.Id,
                privateMessage.FromUserId, fromUser?.UserName, privateMessage.ToUserId, toUser.UserName,
                privateMessage.CreationTime, privateMessage.ReadTime!.Value, privateMessage.Title, privateMessage.Category);

            privateMessage.MapExtraPropertiesTo(eto, MappingPropertyDefinitionChecks.None);

            await _distributedEventBus.PublishAsync(eto);
        }

        public virtual async Task<long> CountAsync(Guid userId, bool unreadOnly = false, string category = null)
        {
            return await _repository.CountReceivingAsync(userId, unreadOnly, category);
        }

        public virtual async Task<IReadOnlyList<PrivateMessage>> GetListAsync(Guid userId, int skipCount,
            int maxResultCount, bool unreadOnly = false, string category = null)
        {
            return await _repository.GetListReceivingAsync(userId, skipCount, maxResultCount, unreadOnly, category);
        }

        public virtual async Task DeleteAsync(PrivateMessage privateMessage)
        {
            await _privateMessageNotificationRepository.DeleteByPrivateMessageIdAsync(new[] { privateMessage.Id });

            await _repository.DeleteAsync(privateMessage, true);
        }
    }
}