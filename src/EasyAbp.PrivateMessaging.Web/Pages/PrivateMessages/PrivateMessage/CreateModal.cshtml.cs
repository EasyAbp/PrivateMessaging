using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.PrivateMessaging.PrivateMessages;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessages.PrivateMessage
{
    public class CreateModalModel : PrivateMessagingPageModel
    {
        [BindProperty]
        public CreateUpdatePrivateMessageDto PrivateMessage { get; set; }

        private readonly IPrivateMessageAppService _service;

        public CreateModalModel(IPrivateMessageAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(PrivateMessage);
            return NoContent();
        }
    }
}