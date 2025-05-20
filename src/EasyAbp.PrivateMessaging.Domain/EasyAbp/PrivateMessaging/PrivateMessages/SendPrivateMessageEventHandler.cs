using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class SendPrivateMessageEventHandler : IDistributedEventHandler<SendPrivateMessageEto>, ITransientDependency
    {
        private readonly IPrivateMessageSenderSideManager _manager;
        private readonly IPrivateMessageRepository _privateMessageRepository;
        private readonly IExternalUserLookupServiceProvider _externalUserLookupServiceProvider;

        public SendPrivateMessageEventHandler(
            IPrivateMessageSenderSideManager manager,
            IPrivateMessageRepository privateMessageRepository,
            IExternalUserLookupServiceProvider externalUserLookupServiceProvider)
        {
            _manager = manager;
            _privateMessageRepository = privateMessageRepository;
            _externalUserLookupServiceProvider = externalUserLookupServiceProvider;
        }

        [UnitOfWork(true)]
        public virtual async Task HandleEventAsync(SendPrivateMessageEto eventData)
        {
            var fromUser = eventData.FromUserId.HasValue
                ? await _externalUserLookupServiceProvider.FindByIdAsync(eventData.FromUserId.Value)
                : null;

            var toUser = await _externalUserLookupServiceProvider.FindByIdAsync(eventData.ToUserId);

            var privateMessage = await _manager.CreateAsync(fromUser, toUser, eventData.Title, eventData.Content, eventData.Category);

            eventData.MapExtraPropertiesTo(privateMessage, MappingPropertyDefinitionChecks.None);

            await _privateMessageRepository.InsertAsync(privateMessage, true);
        }
    }
}