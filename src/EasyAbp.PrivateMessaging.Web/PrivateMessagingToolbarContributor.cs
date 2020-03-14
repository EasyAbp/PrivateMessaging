using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.Web.Pages.Components.PmNotification;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;

namespace EasyAbp.PrivateMessaging.Web
{
    public class PrivateMessagingToolbarContributor : IToolbarContributor
    {
        public virtual async Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name != StandardToolbars.Main)
            {
                return;
            }
            
            context.Toolbar.Items.Insert(0, new ToolbarItem(typeof(PmNotificationViewComponent)));
        }
    }
}