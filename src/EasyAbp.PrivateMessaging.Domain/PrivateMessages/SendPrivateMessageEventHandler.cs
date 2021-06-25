using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class SendPrivateMessageEventHandler : IDistributedEventHandler<SendPrivateMessageEto>, ITransientDependency
    {
        private readonly IPrivateMessageSenderSideManager _manager;
        private readonly IExternalUserLookupServiceProvider _externalUserLookupServiceProvider;

        public SendPrivateMessageEventHandler(
            IPrivateMessageSenderSideManager manager,
            IExternalUserLookupServiceProvider externalUserLookupServiceProvider)
        {
            _manager = manager;
            _externalUserLookupServiceProvider = externalUserLookupServiceProvider;
        }
        
        [UnitOfWork]
        public virtual async Task HandleEventAsync(SendPrivateMessageEto eventData)
        {
            var fromUser = eventData.FromUserId.HasValue
                ? await _externalUserLookupServiceProvider.FindByIdAsync(eventData.FromUserId.Value)
                : null;
            
            var toUser = await _externalUserLookupServiceProvider.FindByIdAsync(eventData.ToUserId);

            await _manager.CreateAsync(fromUser, toUser, eventData.Title, eventData.Content);
        }
    }
}