using EasyAbp.PrivateMessaging.UnifiedDemo;
using EasyAbp.PrivateMessaging.UnifiedDemo.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.UnifiedDemo.SettingManagement;

public abstract class SettingManagementAppServiceBase : ApplicationService
{
    protected SettingManagementAppServiceBase()
    {
        ObjectMapperContext = typeof(UnifiedDemoApplicationModule);
        LocalizationResource = typeof(UnifiedDemoResource);
    }
}
