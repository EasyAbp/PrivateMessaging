using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessaging.Components.PmNotification
{
    [Widget(RefreshUrl = "/widgets/pm-notification")]
    [ViewComponent(Name = "PmNotification")]
    public class PmNotificationViewComponent : AbpViewComponent
    {
        public virtual async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Pages/PrivateMessaging/Components/PmNotification/Default.cshtml");
        }
    }
}