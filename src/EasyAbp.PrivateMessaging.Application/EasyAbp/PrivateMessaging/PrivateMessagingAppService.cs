using EasyAbp.PrivateMessaging.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging
{
    public abstract class PrivateMessagingAppService : ApplicationService
    {
        protected PrivateMessagingAppService()
        {
            LocalizationResource = typeof(PrivateMessagingResource);
            ObjectMapperContext = typeof(PrivateMessagingApplicationModule);
        }
    }
}
