using System;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessages;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using EasyAbp.PrivateMessaging.Web.Pages.PrivateMessages.InfoModels;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessages
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