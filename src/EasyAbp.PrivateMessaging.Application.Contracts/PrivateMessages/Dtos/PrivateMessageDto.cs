using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PrivateMessaging.PrivateMessages.Dtos
{
    public class PrivateMessageDto : FullAuditedEntityDto<Guid>
    {
        public Guid? TenantId { get; set; }

        public Guid ToUserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? ReadTime { get; set; }
    }
}