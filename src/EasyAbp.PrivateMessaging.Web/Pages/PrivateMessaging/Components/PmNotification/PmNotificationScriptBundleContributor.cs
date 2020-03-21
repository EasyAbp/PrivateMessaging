using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessaging.Components.PmNotification
{
    [DependsOn(typeof(SharedThemeGlobalScriptContributor))]
    public class PmNotificationScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/Pages/PrivateMessaging/Components/PmNotification/Default.js");
        }
    }
}