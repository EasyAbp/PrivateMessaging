using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.PrivateMessaging.PrivateMessages;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using EasyAbp.PrivateMessaging.Web.Pages.PrivateMessages.PrivateMessage.InfoModels;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessages.PrivateMessage
{
    public class DetailModalModel : PrivateMessagingPageModel
    {
        public PrivateMessageInfoModel PrivateMessage { get; set; }

        private readonly IPrivateMessageAppService _service;

        public DetailModalModel(IPrivateMessageAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync(Guid id)
        {
            PrivateMessage = ObjectMapper.Map<PrivateMessageDto, PrivateMessageInfoModel>(await _service.GetAsync(id));
        }
    }
}