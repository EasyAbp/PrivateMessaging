using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.PrivateMessaging.Controllers.Widgets
{
    [Route("Widgets")]
    public class PmNotificationWidgetsController : AbpController
    {
        [HttpGet]
        [Route("PmNotification")]
        public IActionResult PmNotification()
        {
            return ViewComponent("PmNotification");
        }
    }
}