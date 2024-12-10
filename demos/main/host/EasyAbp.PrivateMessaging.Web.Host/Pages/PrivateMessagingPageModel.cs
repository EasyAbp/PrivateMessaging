using EasyAbp.PrivateMessaging.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.PrivateMessaging.Pages
{
    public abstract class PrivateMessagingPageModel : AbpPageModel
    {
        protected PrivateMessagingPageModel()
        {
            LocalizationResourceType = typeof(PrivateMessagingResource);
        }
    }
}