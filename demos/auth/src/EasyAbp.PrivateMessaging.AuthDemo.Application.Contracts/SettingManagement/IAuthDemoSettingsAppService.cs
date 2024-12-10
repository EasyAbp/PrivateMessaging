using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.AuthDemo.SettingManagement;

public interface IAuthDemoSettingsAppService : IApplicationService
{
    Task<AuthDemoSettingsDto> GetAsync();

    Task UpdateAsync(UpdateAuthDemoSettingsDto input);
}
