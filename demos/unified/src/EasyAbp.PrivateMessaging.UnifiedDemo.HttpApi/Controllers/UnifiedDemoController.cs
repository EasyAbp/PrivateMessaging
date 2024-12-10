using EasyAbp.PrivateMessaging.UnifiedDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.PrivateMessaging.UnifiedDemo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class UnifiedDemoController : AbpControllerBase
{
    protected UnifiedDemoController()
    {
        LocalizationResource = typeof(UnifiedDemoResource);
    }
}
