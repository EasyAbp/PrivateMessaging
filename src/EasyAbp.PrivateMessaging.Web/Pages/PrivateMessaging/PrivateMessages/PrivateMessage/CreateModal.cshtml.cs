using System;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessages;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using EasyAbp.PrivateMessaging.Web.Pages.PrivateMessaging.PrivateMessages.PrivateMessage.InfoModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessaging.PrivateMessages.PrivateMessage
{
    public class CreateModalModel : PrivateMessagingPageModel
    {
        [BindProperty]
        public CreatePrivateMessageInfoModel PrivateMessage { get; set; }

        private readonly IPrivateMessageAppService _service;

        public CreateModalModel(IPrivateMessageAppService service)
        {
            _service = service;
        }

        public virtual Task OnGetAsync(string toUserName)
        {
            if (!toUserName.IsNullOrEmpty())
            {
                PrivateMessage = new CreatePrivateMessageInfoModel
                {
                    ToUserName = toUserName
                };
            }
            
            return Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(
                ObjectMapper.Map<CreatePrivateMessageInfoModel, CreateUpdatePrivateMessageDto>(PrivateMessage));
            
            return NoContent();
        }
    }
}