using System;
using System.ComponentModel;
namespace EasyAbp.PrivateMessaging.PrivateMessages.Dtos
{
    public class CreateUpdatePrivateMessageDto
    {
        [DisplayName("PrivateMessageTenantId")]
        public Guid? TenantId { get; set; }

        [DisplayName("PrivateMessageToUserId")]
        public Guid ToUserId { get; set; }

        [DisplayName("PrivateMessageTitle")]
        public string Title { get; set; }

        [DisplayName("PrivateMessageContent")]
        public string Content { get; set; }

        [DisplayName("PrivateMessageReadTime")]
        public DateTime? ReadTime { get; set; }
    }
}