using EasyAbp.PrivateMessaging.AuthDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.PrivateMessaging.AuthDemo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AuthDemoController : AbpControllerBase
{
    protected AuthDemoController()
    {
        LocalizationResource = typeof(AuthDemoResource);
    }
}
