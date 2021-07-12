using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Distributed;
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
        
        public virtual async Task<long> CountAsync(Guid userId)
        {
            using (_dataFilter.Disable<ISoftDelete>())
            {
                return await _repository.CountSendingAsync(userId);
            }
        }

        public virtual async Task<IReadOnlyList<PrivateMessage>> GetListAsync(Guid userId, int skipCount, int maxResultCount)
        {
            using (_dataFilter.Disable<ISoftDelete>())
            {
                return await _repository.GetListSendingAsync(userId, skipCount, maxResultCount);
            }
        }

        public virtual Task<PrivateMessage> CreateAsync(IUserData fromUser, IUserData toUser, string title,
            string content)
        {
            var privateMessage = new PrivateMessage(GuidGenerator.Create(), CurrentTenant.Id, fromUser?.Id, toUser.Id,
                title, content);

            _unitOfWorkManager.Current.OnCompleted(async () =>
                await _distributedEventBus.PublishAsync(new PrivateMessageSentEto(privateMessage.TenantId,
                    privateMessage.Id, fromUser?.Id, fromUser?.UserName, toUser.Id, toUser.UserName,
                    privateMessage.CreationTime, privateMessage.Title)));
            
            return Task.FromResult(privateMessage);
        }
    }
}