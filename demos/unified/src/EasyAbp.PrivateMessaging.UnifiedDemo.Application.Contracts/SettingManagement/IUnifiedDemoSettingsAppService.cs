using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.UnifiedDemo.SettingManagement;

public interface IUnifiedDemoSettingsAppService : IApplicationService
{
    Task<UnifiedDemoSettingsDto> GetAsync();

    Task UpdateAsync(UpdateUnifiedDemoSettingsDto input);
}
