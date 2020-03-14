using System.Threading.Tasks;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessages.PrivateMessage
{
    public class InboxModel : PrivateMessagingPageModel
    {
        public async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
