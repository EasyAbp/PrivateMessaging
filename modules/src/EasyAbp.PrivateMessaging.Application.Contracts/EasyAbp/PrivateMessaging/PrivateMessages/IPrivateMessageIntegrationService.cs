using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessages;

[IntegrationService]
public interface IPrivateMessageIntegrationService : IApplicationService
{
    Task<PrivateMessageDto> CreateAsync(CreatePrivateMessageInfoModel input);
}