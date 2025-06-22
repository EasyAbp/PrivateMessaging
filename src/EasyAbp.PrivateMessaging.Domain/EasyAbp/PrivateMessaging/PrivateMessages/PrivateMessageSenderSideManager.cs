using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    [UnitOfWork]
    public class PrivateMessageSenderSideManager : DomainService, IPrivateMessageSenderSideManager
    {
        private readonly IDataFilter _dataFilter;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IDistributedEventBus _distributedEventBus;
        private readonly IPrivateMessageRepository _repository;

        public PrivateMessageSenderSideManager(
            IDataFilter dataFilter,
            IUnitOfWorkManager unitOfWorkManager,
            IDistributedEventBus distributedEventBus,
            IPrivateMessageRepository repository)
        {
            _dataFilter = dataFilter;
            _unitOfWorkManager = unitOfWorkManager;
            _distributedEventBus = distributedEventBus;
            _repository = repository;
        }

        public virtual async Task<long> CountAsync(Guid userId, string category = null)
        {
            using (_dataFilter.Disable<ISoftDelete>())
            {
                return await _repository.CountSendingAsync(userId, category: category);
            }
        }

        public virtual async Task<IReadOnlyList<PrivateMessage>> GetListAsync(Guid userId, int skipCount,
            int maxResultCount, string category = null)
        {
            using (_dataFilter.Disable<ISoftDelete>())
            {
                return await _repository.GetListSendingAsync(userId, skipCount, maxResultCount, category: category);
            }
        }

        [UnitOfWork(true)]
        public virtual Task<PrivateMessage> CreateAsync(IUserData fromUser, IUserData toUser, string title,
            string content, string category = null)
        {
            var privateMessage = new PrivateMessage(
                GuidGenerator.Create(), CurrentTenant.Id, fromUser?.Id, toUser.Id, title, content, category);

            var eto = new PrivateMessageSentEto(privateMessage.TenantId, privateMessage.Id, fromUser?.Id,
                fromUser?.UserName, toUser.Id, toUser.UserName, privateMessage.CreationTime, privateMessage.Title, privateMessage.Category);

            privateMessage.MapExtraPropertiesTo(eto, MappingPropertyDefinitionChecks.None);

            privateMessage.AddDistributedEvent(eto);

            return Task.FromResult(privateMessage);
        }
    }
}