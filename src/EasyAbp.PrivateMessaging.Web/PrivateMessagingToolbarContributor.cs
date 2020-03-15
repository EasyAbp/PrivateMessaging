using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.Authorization;
using EasyAbp.PrivateMessaging.Web.Pages.Components.PmNotification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
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

            var authorizationService = context.ServiceProvider.GetService<IAuthorizationService>();

            if (await authorizationService.IsGrantedAsync(
                PrivateMessagingPermissions.PrivateMessageNotifications.Default))
            {
                context.Toolbar.Items.Insert(0, new ToolbarItem(typeof(PmNotificationViewComponent)));
            }
        }
    }
}