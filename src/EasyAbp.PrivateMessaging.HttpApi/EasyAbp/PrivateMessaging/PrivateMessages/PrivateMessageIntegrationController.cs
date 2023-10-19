using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace EasyAbp.PrivateMessaging.PrivateMessages;

[RemoteService(Name = PrivateMessagingRemoteServiceConsts.RemoteServiceName)]
[Route("/integration-api/private-messaging/private-message")]
public class PrivateMessageIntegrationController : PrivateMessagingController, IPrivateMessageIntegrationService
{
    private readonly IPrivateMessageIntegrationService _service;

    public PrivateMessageIntegrationController(IPrivateMessageIntegrationService service)
    {
        _service = service;
    }

    [HttpPost]
    public virtual Task<PrivateMessageDto> CreateAsync(CreatePrivateMessageInfoModel input)
    {
        return _service.CreateAsync(input);
    }
}