using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using EasyAbp.PrivateMessaging.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.PrivateMessaging.Pages
{
    public abstract class PrivateMessagingPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<PrivateMessagingResource> L { get; set; }
    }
}
