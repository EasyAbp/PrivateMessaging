using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.Authorization;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    [Authorize]
    public class PrivateMessageNotificationAppService : ApplicationService, IPrivateMessageNotificationAppService
    {
        private readonly IPrivateMessageNotificationManager _notificationManager;
        private readonly IPrivateMessageNotificationRepository _repository;

        public PrivateMessageNotificationAppService(
            IPrivateMessageNotificationManager notificationManager,
            IPrivateMessageNotificationRepository repository)
        {
            _notificationManager = notificationManager;
            _repository = repository;
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessageNotifications.Default)]
        public async Task<long> CountAsync()
        {
            return await _repository.CountByUserIdAsync(CurrentUser.GetId());
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessageNotifications.Delete)]
        public async Task DeleteAsync(IEnumerable<Guid> ids)
        {
            foreach (var id in ids)
            {
                var notification = await _repository.GetAsync(id);

                await AuthorizationService.CheckAsync(notification,
                    PrivateMessagingPermissions.PrivateMessageNotifications.Delete);
                
                await _notificationManager.DeleteAsync(notification);
            }
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessageNotifications.Default)]
        public async Task<PagedResultDto<PrivateMessageNotificationDto>> GetListAsync(PagedResultRequestDto input)
        {
            var count = await _repository.CountByUserIdAsync(CurrentUser.GetId());

            var list = await _repository.GetListByUserIdAsync(CurrentUser.GetId(), input.SkipCount,
                input.MaxResultCount);
            
            return new PagedResultDto<PrivateMessageNotificationDto>(count,
                ObjectMapper.Map<IReadOnlyList<PrivateMessageNotification>, IReadOnlyList<PrivateMessageNotificationDto>>(list));
        }
    }
}