using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos
{
    public class PrivateMessageNotificationDto : EntityDto<Guid>
    {
        public Guid? TenantId { get; set; }

        public Guid UserId { get; set; }

        public Guid PrivateMessageId { get; set; }
    }
}