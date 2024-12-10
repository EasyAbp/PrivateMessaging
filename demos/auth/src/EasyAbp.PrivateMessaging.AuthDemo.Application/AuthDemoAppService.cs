using EasyAbp.PrivateMessaging.AuthDemo.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.AuthDemo;

/* Inherit your application services from this class.
 */
public abstract class AuthDemoAppService : ApplicationService
{
    protected AuthDemoAppService()
    {
        LocalizationResource = typeof(AuthDemoResource);
    }
}
