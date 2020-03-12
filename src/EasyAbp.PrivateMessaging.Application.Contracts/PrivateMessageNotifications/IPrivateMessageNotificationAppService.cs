using System;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public interface IPrivateMessageNotificationAppService :
        ICrudAppService< 
            PrivateMessageNotificationDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdatePrivateMessageNotificationDto,
            CreateUpdatePrivateMessageNotificationDto>
    {

    }
}