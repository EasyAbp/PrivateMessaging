using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.Authorization;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using EasyAbp.PrivateMessaging.Users;
using EasyAbp.PrivateMessaging.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    [Authorize]
    public class PrivateMessageAppService : ApplicationService, IPrivateMessageAppService
    {
        private readonly IDataFilter _dataFilter;
        private readonly IExternalUserLookupServiceProvider _externalUserLookupServiceProvider;
        private readonly IPrivateMessageRepository _privateMessageRepository;
        private readonly IPrivateMessageNotificationManager _notificationManager;
        private readonly IPrivateMessageSenderSideManager _privateMessageSenderSideManager;
        private readonly IPrivateMessageReceiverSideManager _privateMessageReceiverSideManager;

        public PrivateMessageAppService(
            IDataFilter dataFilter,
            IExternalUserLookupServiceProvider externalUserLookupServiceProvider,
            IPrivateMessageRepository privateMessageRepository,
            IPrivateMessageNotificationManager notificationManager,
            IPrivateMessageSenderSideManager privateMessageSenderSideManager,
            IPrivateMessageReceiverSideManager privateMessageReceiverSideManager)
        {
            _dataFilter = dataFilter;
            _externalUserLookupServiceProvider = externalUserLookupServiceProvider;
            _privateMessageRepository = privateMessageRepository;
            _notificationManager = notificationManager;
            _privateMessageSenderSideManager = privateMessageSenderSideManager;
            _privateMessageReceiverSideManager = privateMessageReceiverSideManager;
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessages.Default)]
        public virtual async Task<PrivateMessageDto> GetAsync(Guid id)
        {
            using (_dataFilter.Disable<ISoftDelete>())
            {
                var message = await _privateMessageRepository.GetAsync(id);

                await AuthorizationService.CheckAsync(message, PrivateMessagingPermissions.PrivateMessages.Default);

                return await MapToDtoAndLoadMoreInfosAsync(message);
            }
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessages.Default)]
        public virtual async Task<PagedResultDto<PrivateMessageDto>> GetListAsync(PagedResultRequestDto input)
        {
            var list = await _privateMessageReceiverSideManager.GetListAsync(CurrentUser.GetId(), input.SkipCount,
                input.MaxResultCount);

            var count = await _privateMessageReceiverSideManager.CountAsync(CurrentUser.GetId());

            return new PagedResultDto<PrivateMessageDto>(count, await MapToDtoAndLoadMoreInfosAsync(list));
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessages.Default)]
        public virtual async Task<PagedResultDto<PrivateMessageDto>> GetListUnreadAsync(PagedResultRequestDto input)
        {
            var list = await _privateMessageReceiverSideManager.GetListAsync(CurrentUser.GetId(), input.SkipCount,
                input.MaxResultCount, true);

            var count = await _privateMessageReceiverSideManager.CountAsync(CurrentUser.GetId(), true);

            return new PagedResultDto<PrivateMessageDto>(count, await MapToDtoAndLoadMoreInfosAsync(list));
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessages.Default)]
        public virtual async Task<PagedResultDto<PrivateMessageDto>> GetListSentAsync(PagedResultRequestDto input)
        {
            var list = await _privateMessageSenderSideManager.GetListAsync(CurrentUser.GetId(), input.SkipCount,
                input.MaxResultCount);

            var count = await _privateMessageSenderSideManager.CountAsync(CurrentUser.GetId());

            return new PagedResultDto<PrivateMessageDto>(count, await MapToDtoAndLoadMoreInfosAsync(list));
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessages.Delete)]
        public virtual async Task DeleteAsync(IEnumerable<Guid> ids)
        {
            var messageList = await _privateMessageRepository.GetListAsync(ids);
            
            foreach (var message in messageList)
            {
                await AuthorizationService.CheckAsync(message, PrivateMessagingPermissions.PrivateMessages.Delete);

                await _privateMessageReceiverSideManager.DeleteAsync(message);
            }
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessages.SetRead)]
        public virtual async Task SetReadAsync(IEnumerable<Guid> ids)
        {
            var messageList = await _privateMessageRepository.GetListAsync(ids);

            foreach (var message in messageList)
            {
                await AuthorizationService.CheckAsync(message, PrivateMessagingPermissions.PrivateMessages.SetRead);

                await _privateMessageReceiverSideManager.SetReadAsync(message);
            }
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessages.Create)]
        public virtual async Task<PrivateMessageDto> CreateAsync(CreateUpdatePrivateMessageDto input)
        {
            var toUser = await _externalUserLookupServiceProvider.FindByUserNameAsync(input.ToUserName);

            var message = await _privateMessageSenderSideManager.CreateAsync(new PrivateMessage(GuidGenerator.Create(),
                CurrentTenant.Id, toUser.Id, input.Title, input.Content));

            await _notificationManager.CreateAsync(new PrivateMessageNotification(GuidGenerator.Create(),
                toUser.Id, message.Id, message.GetTitlePreview()));

            return await MapToDtoAndLoadMoreInfosAsync(message);
        }

        private async Task<IReadOnlyList<PrivateMessageDto>> MapToDtoAndLoadMoreInfosAsync(
            IReadOnlyList<PrivateMessage> entityList)
        {
            var dtoList = ObjectMapper.Map<IReadOnlyList<PrivateMessage>, IReadOnlyList<PrivateMessageDto>>(entityList);

            var toUserIds = dtoList.Select(dto => dto.ToUserId);
            var creatorIds = dtoList.Where(dto => dto.CreatorId.HasValue).Select(dto => dto.CreatorId.Value);

            var userIds = toUserIds.Concat(creatorIds).Distinct().ToList();

            var userDtoDict = new Dictionary<Guid, PmUserDto>();

            foreach (var userId in userIds)
            {
                userDtoDict[userId] =
                    ObjectMapper.Map<IUserData, PmUserDto>(await _externalUserLookupServiceProvider.FindByIdAsync(userId));
            }
            
            foreach (var dto in dtoList)
            {
                dto.ToUser = userDtoDict[dto.ToUserId];

                if (dto.CreatorId.HasValue)
                {
                    dto.Creator = userDtoDict[dto.CreatorId.Value];
                }
            }

            return dtoList;
        }

        private async Task<PrivateMessageDto> MapToDtoAndLoadMoreInfosAsync(PrivateMessage entity)
        {
            return (await MapToDtoAndLoadMoreInfosAsync(new[] {entity})).First();
        }
    }
}