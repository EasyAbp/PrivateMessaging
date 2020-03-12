using System;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public class PrivateMessageNotificationAppService : CrudAppService<PrivateMessageNotification, PrivateMessageNotificationDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePrivateMessageNotificationDto, CreateUpdatePrivateMessageNotificationDto>,
        IPrivateMessageNotificationAppService
    {
        private readonly IPrivateMessageNotificationRepository _repository;

        public PrivateMessageNotificationAppService(IPrivateMessageNotificationRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}