using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace EasyAbp.PrivateMessaging.Pages
{
    public class IndexModel : PrivateMessagingPageModel
    {
        public void OnGet()
        {
            
        }

        public virtual async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}