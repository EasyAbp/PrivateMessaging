using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using EasyAbp.PrivateMessaging.Localization;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.PrivateMessaging.Web
{
    public class PrivateMessagingMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<PrivateMessagingResource>>();            //Add main menu items.

            context.Menu.AddItem(
                new ApplicationMenuItem("PrivateMessage", l["Menu:PrivateMessage"], "/PrivateMessages/PrivateMessage")
            );
            return Task.CompletedTask;
        }
    }
}
