using System;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public interface IPrivateMessageNotificationAppService : IApplicationService
    {
        Task<long> CountAsync();
    
        Task<PagedResultDto<PrivateMessageNotificationDto>> GetListAsync(PagedResultRequestDto input);
    }
}