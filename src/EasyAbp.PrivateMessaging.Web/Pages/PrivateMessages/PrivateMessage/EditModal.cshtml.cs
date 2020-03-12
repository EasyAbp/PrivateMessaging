using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.PrivateMessaging.PrivateMessages;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessages.PrivateMessage
{
    public class EditModalModel : PrivateMessagingPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdatePrivateMessageDto PrivateMessage { get; set; }

        private readonly IPrivateMessageAppService _service;

        public EditModalModel(IPrivateMessageAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            PrivateMessage = ObjectMapper.Map<PrivateMessageDto, CreateUpdatePrivateMessageDto>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, PrivateMessage);
            return NoContent();
        }
    }
}