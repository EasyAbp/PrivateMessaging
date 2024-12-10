using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicMenu.Localization;
using EasyAbp.Abp.DynamicMenu.MenuItems;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using EasyAbp.Abp.DynamicMenu.Permissions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Authorization;
using Volo.Abp.Security.Claims;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.Abp.DynamicMenu.Web.Menus
{
    public class DemoMenuContributor : IMenuContributor
    {
        private ILogger<DemoMenuContributor> _logger;
        private IAbpAuthorizationPolicyProvider _policyProvider;
        private ICurrentPrincipalAccessor _currentPrincipalAccessor;
        private IMenuItemAppService _menuItemAppService;
        private IDynamicMenuStringLocalizerProvider _stringLocalizerProvider;

        private Dictionary<string, StringLocalizerModel> ModuleNameStringLocalizers { get; set; } = new();

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            var loggerFactory = context.ServiceProvider.GetRequiredService<ILoggerFactory>();
            _logger = loggerFactory.CreateLogger<DemoMenuContributor>();
            _policyProvider = context.ServiceProvider.GetRequiredService<IAbpAuthorizationPolicyProvider>();
            _currentPrincipalAccessor = context.ServiceProvider.GetRequiredService<ICurrentPrincipalAccessor>();
            _menuItemAppService = context.ServiceProvider.GetRequiredService<IMenuItemAppService>();
            _stringLocalizerProvider =
                context.ServiceProvider.GetRequiredService<IDynamicMenuStringLocalizerProvider>();

            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        protected virtual async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var menuItems = await _menuItemAppService.GetListAsync(new GetMenuItemListInput
            {
                MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount,
                ParentName = null
            });

            await AddDynamicMenuItemsAsync(menuItems.Items, context);
            await AddDynamicMenuManagementMenuItemAsync(context);
        }

        protected virtual async Task AddDynamicMenuManagementMenuItemAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<DynamicMenuResource>();

            var dynamicMenu = new ApplicationMenuItem(DemoMenus.Prefix, displayName: l["Menu:DynamicMenu"],
                "~/Abp/DynamicMenu", icon: "fa fa-bars");

            if (await context.IsGrantedAsync(DynamicMenuPermissions.MenuItem.Default))
            {
                dynamicMenu.AddItem(
                    new ApplicationMenuItem(DemoMenus.MenuItem, l["Menu:MenuItem"],
                        "~/Abp/DynamicMenu/MenuItems/MenuItem")
                );
            }

            if (dynamicMenu.Items.Any())
            {
                context.Menu.GetAdministration().AddItem(dynamicMenu);
            }
        }

        protected virtual async Task AddDynamicMenuItemsAsync(IReadOnlyCollection<MenuItemDto> menuItems,
            MenuConfigurationContext context)
        {
            await AddDynamicMenuItemsAsync(context.Menu,
                menuItems.Where(x => !x.InAdministration), context);

            await AddDynamicMenuItemsAsync(context.Menu.GetAdministration(),
                menuItems.Where(x => x.InAdministration), context);
        }

        protected virtual async Task AddDynamicMenuItemsAsync(IHasMenuItems parent, IEnumerable<MenuItemDto> menuItems,
            MenuConfigurationContext context)
        {
            foreach (var menuItem in menuItems.Where(x => !x.IsDisabled))
            {
                if (menuItem.Permission != null && !await IsFoundAndGrantedAsync(menuItem.Permission, context))
                {
                    continue;
                }

                var l = await GetOrCreateStringLocalizerAsync(menuItem, _stringLocalizerProvider);

                var child = new ApplicationMenuItem(menuItem.Name, l[menuItem.DisplayName],
                    order: menuItem.Order ?? default, icon: menuItem.Icon);

                if (menuItem.MenuItems.IsNullOrEmpty())
                {
                    child.Url = menuItem.UrlBlazor ?? menuItem.Url;
                    child.Target = menuItem.Target;
                }
                else
                {
                    await AddDynamicMenuItemsAsync(child, menuItem.MenuItems, context);
                }

                parent.Items.Add(child);
            }
        }

        protected virtual async Task<bool> IsFoundAndGrantedAsync(string policyName, MenuConfigurationContext context)
        {
            if (policyName == null)
            {
                throw new ArgumentNullException(nameof(policyName));
            }

            var policy = await _policyProvider.GetPolicyAsync(policyName);

            if (policy == null)
            {
                _logger.LogWarning($"[Entity UI] No policy found: {policyName}.");

                return false;
            }

            return (await context.AuthorizationService.AuthorizeAsync(
                _currentPrincipalAccessor.Principal,
                null,
                policyName)).Succeeded;
        }

        protected virtual async Task<IStringLocalizer> GetOrCreateStringLocalizerAsync(MenuItemDto menuItem,
            IDynamicMenuStringLocalizerProvider stringLocalizerProvider)
        {
            if (ModuleNameStringLocalizers.ContainsKey(menuItem.Name) &&
                ModuleNameStringLocalizers[menuItem.Name].LResourceTypeName == menuItem.LResourceTypeName &&
                ModuleNameStringLocalizers[menuItem.Name].LResourceTypeAssemblyName ==
                menuItem.LResourceTypeAssemblyName)
            {
                return ModuleNameStringLocalizers[menuItem.Name].StringLocalizer;
            }

            var localizer = await stringLocalizerProvider.GetAsync(menuItem);

            ModuleNameStringLocalizers[menuItem.Name] = new StringLocalizerModel
            {
                LResourceTypeName = menuItem.LResourceTypeName,
                LResourceTypeAssemblyName = menuItem.LResourceTypeAssemblyName,
                StringLocalizer = localizer
            };

            return localizer;
        }
    }
}