using System;
using EasyAbp.PrivateMessaging.Users.Dtos;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PrivateMessaging.PrivateMessages.Dtos
{
    public class PrivateMessageDto : FullAuditedEntityDto<Guid>
    {
        public Guid? FromUserId { get; set; }
        
        public Guid ToUserId { get; set; }

        [CanBeNull]
        public PmUserDto FromUser { get; set; }
        
        public PmUserDto ToUser { get; set; }
        
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? ReadTime { get; set; }
    }
}