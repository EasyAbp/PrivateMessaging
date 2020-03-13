using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.PrivateMessaging.PrivateMessages.Dtos
{
    public class CreateUpdatePrivateMessageDto
    {
        [Required]
        [DisplayName("PrivateMessageToUserName")]
        public string ToUserName { get; set; }

        [Required]
        [MaxLength(PrivateMessageConsts.TitleMaxLength)]
        [DisplayName("PrivateMessageTitle")]
        public string Title { get; set; }

        [MaxLength(PrivateMessageConsts.ContentMaxLength)]
        [DisplayName("PrivateMessageContent")]
        public string Content { get; set; }
    }
}