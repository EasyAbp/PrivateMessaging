using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public interface IPrivateMessageNotificationAppService : IApplicationService
    {
        Task<long> CountAsync(string category = null);
        
        Task DeleteAsync(IEnumerable<Guid> ids);
    
        Task<PagedResultDto<PrivateMessageNotificationDto>> GetListAsync(GetPrivateMessageNotificationInput input);
    }
}