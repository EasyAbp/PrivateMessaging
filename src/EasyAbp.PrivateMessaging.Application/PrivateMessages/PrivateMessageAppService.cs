using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using EasyAbp.PrivateMessaging.Users;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class PrivateMessageAppService : ApplicationService, IPrivateMessageAppService
    {
        private readonly IPmUserLookupService _pmUserLookupService;
        private readonly IPrivateMessageNotificationManager _notificationManager;
        private readonly IPrivateMessageSenderSideManager _privateMessageSenderSideManager;

        public PrivateMessageAppService(
            IPmUserLookupService pmUserLookupService,
            IPrivateMessageNotificationManager notificationManager,
            IPrivateMessageSenderSideManager privateMessageSenderSideManager)
        {
            _pmUserLookupService = pmUserLookupService;
            _notificationManager = notificationManager;
            _privateMessageSenderSideManager = privateMessageSenderSideManager;
        }

        public async Task<PagedResultDto<PrivateMessageDto>> GetListAsync(PagedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<PrivateMessageDto>> GetListUnreadAsync(PagedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<PrivateMessageDto>> GetListSentAsync(PagedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public async Task<PrivateMessageDto> SetReadAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<PrivateMessageDto> CreateAsync(CreateUpdatePrivateMessageDto input)
        {
            var toUser = await _pmUserLookupService.FindByUserNameAsync(input.ToUserName);

            var message = await _privateMessageSenderSideManager.CreateAsync(new PrivateMessage(GuidGenerator.Create(),
                CurrentTenant.Id, toUser.Id, input.Title, input.Content));

            await _notificationManager.CreateAsync(new PrivateMessageNotification(GuidGenerator.Create(),
                toUser.Id, message.Id, message.GetTitlePreview()));

            return ObjectMapper.Map<PrivateMessage, PrivateMessageDto>(message);
        }
    }
}