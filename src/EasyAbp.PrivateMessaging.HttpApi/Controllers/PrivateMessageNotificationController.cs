using EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    [RemoteService]
    [Area("EasyAbp")]
    [ControllerName("PrivateMessageNotification")]
    [Route("api/PrivateMessaging/Components/PmNotification")]
    public class PrivateMessageNotificationController : AbpController, IPrivateMessageNotificationAppService
    {
        protected IPrivateMessageNotificationAppService AppService { get; }

        public PrivateMessageNotificationController(IPrivateMessageNotificationAppService userAppService)
        {
            AppService = userAppService;
        }

        [HttpPost]
        [Route("count")]
        public Task<long> CountAsync()
        {
            return AppService.CountAsync();
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(IEnumerable<Guid> ids)
        {
            return AppService.DeleteAsync(ids);
        }

        [HttpGet]
        public Task<PagedResultDto<PrivateMessageNotificationDto>> GetListAsync(PagedResultRequestDto input)
        {
            return AppService.GetListAsync(input);
        }

    }
}