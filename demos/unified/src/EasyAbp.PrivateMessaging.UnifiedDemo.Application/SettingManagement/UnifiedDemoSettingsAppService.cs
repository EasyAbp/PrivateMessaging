using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Features;
using Volo.Abp.SettingManagement;

namespace EasyAbp.PrivateMessaging.UnifiedDemo.SettingManagement;

//[Authorize(SettingManagementPermissions.Emailing)]
public class UnifiedDemoSettingsAppService(ISettingManager settingManager) : SettingManagementAppServiceBase, IUnifiedDemoSettingsAppService
{
    public virtual async Task<UnifiedDemoSettingsDto> GetAsync()
    {
        await CheckFeatureAsync();

        var settingsDto = new UnifiedDemoSettingsDto
        {
            RememberGridFilterState = Convert.ToBoolean(await SettingProvider.GetOrNullAsync(UnifiedDemoSettingNames.RememberGridFilterState)),
        };

        return settingsDto;
    }

    public virtual async Task UpdateAsync(UpdateUnifiedDemoSettingsDto input)
    {
        await CheckFeatureAsync();

        await settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, UnifiedDemoSettingNames.RememberGridFilterState, input.RememberGridFilterState.ToString().ToLowerInvariant());
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
