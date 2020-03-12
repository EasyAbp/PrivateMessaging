using System;
using System.ComponentModel;
namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos
{
    public class CreateUpdatePrivateMessageNotificationDto
    {
        [DisplayName("PrivateMessageNotificationTenantId")]
        public Guid? TenantId { get; set; }

        [DisplayName("PrivateMessageNotificationUserId")]
        public Guid UserId { get; set; }

        [DisplayName("PrivateMessageNotificationPrivateMessageId")]
        public Guid PrivateMessageId { get; set; }
    }
}