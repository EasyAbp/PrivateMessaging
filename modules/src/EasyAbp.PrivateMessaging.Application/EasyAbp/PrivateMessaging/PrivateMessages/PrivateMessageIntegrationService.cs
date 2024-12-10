using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.PrivateMessages;

public class PrivateMessageIntegrationService : ApplicationService, IPrivateMessageIntegrationService
{
    private readonly IPrivateMessageSenderSideManager _manager;
    private readonly IPrivateMessageRepository _privateMessageRepository;
    private readonly IExternalUserLookupServiceProvider _externalUserLookupServiceProvider;

    public PrivateMessageIntegrationService(
        IPrivateMessageSenderSideManager manager,
        IPrivateMessageRepository privateMessageRepository,
        IExternalUserLookupServiceProvider externalUserLookupServiceProvider)
    {
        _manager = manager;
        _privateMessageRepository = privateMessageRepository;
        _externalUserLookupServiceProvider = externalUserLookupServiceProvider;
    }

    public virtual async Task<PrivateMessageDto> CreateAsync(CreatePrivateMessageInfoModel input)
    {
        var fromUser = input.FromUserId.HasValue
            ? await _externalUserLookupServiceProvider.FindByIdAsync(input.FromUserId.Value)
            : null;

        var toUser = await _externalUserLookupServiceProvider.FindByIdAsync(input.ToUserId);

        var privateMessage = await _manager.CreateAsync(fromUser, toUser, input.Title, input.Content);

        input.MapExtraPropertiesTo(privateMessage, MappingPropertyDefinitionChecks.None);

        await _privateMessageRepository.InsertAsync(privateMessage, true);

        return ObjectMapper.Map<PrivateMessage, PrivateMessageDto>(privateMessage);
    }
}