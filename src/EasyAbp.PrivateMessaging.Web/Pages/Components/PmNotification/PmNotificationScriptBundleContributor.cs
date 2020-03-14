using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging.Web.Pages.Components.PmNotification
{
    [DependsOn(typeof(SharedThemeGlobalScriptContributor))]
    public class PmNotificationScriptBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/Pages/Components/PmNotification/Default.js");
        }
    }
}