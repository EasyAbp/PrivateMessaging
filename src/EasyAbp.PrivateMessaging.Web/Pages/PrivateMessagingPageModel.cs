using EasyAbp.PrivateMessaging.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.PrivateMessaging.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class PrivateMessagingPageModel : AbpPageModel
    {
        protected PrivateMessagingPageModel()
        {
            LocalizationResourceType = typeof(PrivateMessagingResource);
            ObjectMapperContext = typeof(PrivateMessagingWebModule);
        }
    }
}