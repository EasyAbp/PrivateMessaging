using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Features;
using Volo.Abp.SettingManagement;

namespace EasyAbp.PrivateMessaging.MainDemo.SettingManagement;

//[Authorize(SettingManagementPermissions.Emailing)]
public class MainDemoSettingsAppService(ISettingManager settingManager) : SettingManagementAppServiceBase, IMainDemoSettingsAppService
{
    public virtual async Task<MainDemoSettingsDto> GetAsync()
    {
        await CheckFeatureAsync();

        var settingsDto = new MainDemoSettingsDto
        {
            RememberGridFilterState = Convert.ToBoolean(await SettingProvider.GetOrNullAsync(MainDemoSettingNames.RememberGridFilterState)),
        };

        return settingsDto;
    }

    public virtual async Task UpdateAsync(UpdateMainDemoSettingsDto input)
    {
        await CheckFeatureAsync();

        await settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, MainDemoSettingNames.RememberGridFilterState, input.RememberGridFilterState.ToString().ToLowerInvariant());
    }

    protected virtual async Task CheckFeatureAsync()
    {
        await FeatureChecker.CheckEnabledAsync(SettingManagementFeatures.Enable);
        if (CurrentTenant.IsAvailable)
        {
            await FeatureChecker.CheckEnabledAsync(SettingManagementFeatures.AllowChangingEmailSettings);
        }
    }
}
