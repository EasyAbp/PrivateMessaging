using System;
using EasyAbp.PrivateMessaging.Users.Dtos;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PrivateMessaging.PrivateMessages.Dtos
{
    public class PrivateMessageDto : FullAuditedEntityDto<Guid>
    {
        public Guid ToUserId { get; set; }

        public PmUserDto ToUser { get; set; }
        
        public PmUserDto Creator { get; set; }
        
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? ReadTime { get; set; }
    }
}