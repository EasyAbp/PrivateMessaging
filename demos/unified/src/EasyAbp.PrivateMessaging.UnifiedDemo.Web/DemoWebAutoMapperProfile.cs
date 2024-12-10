using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using AutoMapper;
using EasyAbp.Abp.DynamicMenu.Web.Pages.Abp.DynamicMenu.MenuItems.MenuItem.ViewModels;
using Volo.Abp.AutoMapper;

namespace EasyAbp.Abp.DynamicMenu.Web
{
    public class DemoWebAutoMapperProfile : Profile
    {
        public DemoWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<MenuItemDto, EditMenuItemViewModel>();
            CreateMap<CreateMenuItemViewModel, CreateMenuItemDto>().Ignore(x => x.ExtraProperties);
            CreateMap<EditMenuItemViewModel, UpdateMenuItemDto>().Ignore(x => x.ExtraProperties);
        }
    }
}
