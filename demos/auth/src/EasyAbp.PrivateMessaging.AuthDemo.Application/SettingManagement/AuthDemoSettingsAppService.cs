using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Features;
using Volo.Abp.SettingManagement;

namespace EasyAbp.PrivateMessaging.AuthDemo.SettingManagement;

//[Authorize(SettingManagementPermissions.Emailing)]
public class AuthDemoSettingsAppService(ISettingManager settingManager) : SettingManagementAppServiceBase, IAuthDemoSettingsAppService
{
    public virtual async Task<AuthDemoSettingsDto> GetAsync()
    {
        await CheckFeatureAsync();

        var settingsDto = new AuthDemoSettingsDto
        {
            RememberGridFilterState = Convert.ToBoolean(await SettingProvider.GetOrNullAsync(AuthDemoSettingNames.RememberGridFilterState)),
        };

        return settingsDto;
    }

    public virtual async Task UpdateAsync(UpdateAuthDemoSettingsDto input)
    {
        await CheckFeatureAsync();

        await settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, AuthDemoSettingNames.RememberGridFilterState, input.RememberGridFilterState.ToString().ToLowerInvariant());
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
