using EasyAbp.PrivateMessaging.AuthDemo;
using EasyAbp.PrivateMessaging.AuthDemo.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.AuthDemo.SettingManagement;

public abstract class SettingManagementAppServiceBase : ApplicationService
{
    protected SettingManagementAppServiceBase()
    {
        ObjectMapperContext = typeof(AuthDemoApplicationModule);
        LocalizationResource = typeof(AuthDemoResource);
    }
}
