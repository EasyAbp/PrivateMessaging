using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessages;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications;

public class PrivateMessageCreatedEventHandler : ILocalEventHandler<EntityCreatedEventData<PrivateMessage>>,
    ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly IPrivateMessageNotificationRepository _repository;

    public PrivateMessageCreatedEventHandler(
        IGuidGenerator guidGenerator,
        IPrivateMessageNotificationRepository repository)
    {
        _guidGenerator = guidGenerator;
        _repository = repository;
    }

    [UnitOfWork]
    public virtual async Task HandleEventAsync(EntityCreatedEventData<PrivateMessage> eventData)
    {
        await _repository.InsertAsync(new PrivateMessageNotification(
            _guidGenerator.Create(),
            eventData.Entity.TenantId,
            eventData.Entity.ToUserId,
            eventData.Entity.Id,
            eventData.Entity.GetTitlePreview(),
            eventData.Entity.Category));
    }
}