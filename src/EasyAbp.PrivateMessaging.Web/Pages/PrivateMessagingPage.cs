using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using EasyAbp.PrivateMessaging.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.PrivateMessaging.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits EasyAbp.PrivateMessaging.Web.Pages.PrivateMessagingPage
     */
    public abstract class PrivateMessagingPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<PrivateMessagingResource> L { get; set; }
    }
}
