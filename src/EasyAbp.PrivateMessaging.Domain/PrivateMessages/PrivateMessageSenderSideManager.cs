using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class PrivateMessageSenderSideManager : DomainService, IPrivateMessageSenderSideManager
    {
        private readonly IDataFilter _dataFilter;
        private readonly IPrivateMessageRepository _repository;

        public PrivateMessageSenderSideManager(
            IDataFilter dataFilter,
            IPrivateMessageRepository repository)
        {
            _dataFilter = dataFilter;
            _repository = repository;
        }
        
        public async Task<long> CountAsync(Guid userId)
        {
            using (_dataFilter.Disable<ISoftDelete>())
            {
                return await _repository.CountSendingAsync(userId);
            }
        }

        public async Task<IReadOnlyList<PrivateMessage>> GetListAsync(Guid userId, int skipCount, int maxResultCount)
        {
            using (_dataFilter.Disable<ISoftDelete>())
            {
                return await _repository.GetListSendingAsync(userId, skipCount, maxResultCount);
            }
        }

        public async Task<PrivateMessage> CreateAsync(PrivateMessage privateMessage)
        {
            return await _repository.InsertAsync(privateMessage, true);
        }
    }
}