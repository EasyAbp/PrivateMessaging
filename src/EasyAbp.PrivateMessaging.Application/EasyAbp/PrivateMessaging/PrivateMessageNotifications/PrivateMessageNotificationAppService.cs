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
        private readonly IPrivateMessageNotificationRepository _repository;

        public PrivateMessageNotificationAppService(
            IPrivateMessageNotificationRepository repository)
        {
            _repository = repository;
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessageNotifications.Default)]
        public virtual async Task<long> CountAsync(string category = null)
        {
            return await _repository.CountByUserIdAsync(CurrentUser.GetId(), category);
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessageNotifications.Delete)]
        public virtual async Task DeleteAsync(IEnumerable<Guid> ids)
        {
            foreach (var id in ids)
            {
                var notification = await _repository.GetAsync(id);

                await AuthorizationService.CheckAsync(notification,
                    PrivateMessagingPermissions.PrivateMessageNotifications.Delete);
                
                await _repository.DeleteAsync(notification);
            }
        }

        [Authorize(PrivateMessagingPermissions.PrivateMessageNotifications.Default)]
        public virtual async Task<PagedResultDto<PrivateMessageNotificationDto>> GetListAsync(GetPrivateMessageNotificationInput input)
        {
            var count = await _repository.CountByUserIdAsync(CurrentUser.GetId());

            var list = await _repository.GetListByUserIdAsync(CurrentUser.GetId(), input.SkipCount,
                input.MaxResultCount, input.Category);
            
            return new PagedResultDto<PrivateMessageNotificationDto>(count,
                ObjectMapper.Map<IReadOnlyList<PrivateMessageNotification>, IReadOnlyList<PrivateMessageNotificationDto>>(list));
        }
    }
}