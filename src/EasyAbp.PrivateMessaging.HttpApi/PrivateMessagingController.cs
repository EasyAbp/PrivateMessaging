using EasyAbp.PrivateMessaging.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.PrivateMessaging
{
    public abstract class PrivateMessagingController : AbpController
    {
        protected PrivateMessagingController()
        {
            LocalizationResource = typeof(PrivateMessagingResource);
        }
    }
}
