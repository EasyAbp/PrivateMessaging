using EasyAbp.PrivateMessaging.PrivateMessages;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{        
    [RemoteService]
    [Area("EasyAbp")]
    [ControllerName("PrivateMessage")]
    [Route("api/pm/privateMessage")]
    public class PrivateMessageController : AbpController, IPrivateMessageAppService
    {
        protected IPrivateMessageAppService AppService { get; }

        public PrivateMessageController(IPrivateMessageAppService userAppService)
        {
            AppService = userAppService;
        }

        [HttpPost]
        public Task<PrivateMessageDto> CreateAsync(CreateUpdatePrivateMessageDto input)
        {
            return AppService.CreateAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<PrivateMessageDto> GetAsync(Guid id)
        {
            return AppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<PrivateMessageDto>> GetListAsync(PagedResultRequestDto input)
        {
            return AppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("unread")]
        public Task<PagedResultDto<PrivateMessageDto>> GetListUnreadAsync(PagedResultRequestDto input)
        {
            return AppService.GetListUnreadAsync(input);
        }

        [HttpGet]
        [Route("sent")]
        public Task<PagedResultDto<PrivateMessageDto>> GetListSentAsync(PagedResultRequestDto input)
        {
            return AppService.GetListSentAsync(input);
        }

        [HttpDelete]
        public Task DeleteAsync(IEnumerable<Guid> ids)
        {
            return AppService.DeleteAsync(ids);
        }

        [HttpPost]
        [Route("setRead")]
        public Task SetReadAsync(IEnumerable<Guid> ids)
        {
            return AppService.SetReadAsync(ids);
        }


    }


}
