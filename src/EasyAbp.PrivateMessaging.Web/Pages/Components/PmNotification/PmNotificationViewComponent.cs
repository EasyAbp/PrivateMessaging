using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.PrivateMessaging.Web.Pages.Components.PmNotification
{
    [Widget(RefreshUrl = "/Widgets/PmNotification")]
    [ViewComponent(Name = "PmNotification")]
    public class PmNotificationViewComponent : AbpViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Pages/Components/PmNotification/Default.cshtml");
        }
    }
}