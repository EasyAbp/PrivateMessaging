using EasyAbp.PrivateMessaging.MainDemo.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.MainDemo;

/* Inherit your application services from this class.
 */
public abstract class MainDemoAppService : ApplicationService
{
    protected MainDemoAppService()
    {
        LocalizationResource = typeof(MainDemoResource);
    }
}
