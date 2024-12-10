using EasyAbp.PrivateMessaging.MainDemo;
using EasyAbp.PrivateMessaging.MainDemo.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.MainDemo.SettingManagement;

public abstract class SettingManagementAppServiceBase : ApplicationService
{
    protected SettingManagementAppServiceBase()
    {
        ObjectMapperContext = typeof(MainDemoApplicationModule);
        LocalizationResource = typeof(MainDemoResource);
    }
}
