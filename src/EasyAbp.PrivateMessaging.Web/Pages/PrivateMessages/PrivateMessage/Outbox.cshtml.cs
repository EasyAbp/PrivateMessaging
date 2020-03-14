using System.Threading.Tasks;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessages.PrivateMessage
{
    public class OutboxModel : PrivateMessagingPageModel
    {
        public async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
