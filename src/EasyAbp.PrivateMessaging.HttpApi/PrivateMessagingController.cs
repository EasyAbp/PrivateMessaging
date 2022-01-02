using EasyAbp.PrivateMessaging.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.PrivateMessaging
{
    [Area(PrivateMessagingRemoteServiceConsts.ModuleName)]
    public abstract class PrivateMessagingController : AbpController
    {
        protected PrivateMessagingController()
        {
            LocalizationResource = typeof(PrivateMessagingResource);
        }
    }
}
