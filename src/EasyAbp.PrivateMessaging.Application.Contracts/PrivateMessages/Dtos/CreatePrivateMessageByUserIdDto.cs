using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.Validation;

namespace EasyAbp.PrivateMessaging.PrivateMessages.Dtos
{
    public class CreatePrivateMessageByUserIdDto : IHasExtraProperties
    {
        [Required]
        [DisplayName("PrivateMessageToUserId")]
        public string ToUserId { get; set; }

        [Required]
        [DynamicMaxLength(typeof(PrivateMessageConsts), nameof(PrivateMessageConsts.TitleMaxLength))]
        [DisplayName("PrivateMessageTitle")]
        public string Title { get; set; }

        [DynamicMaxLength(typeof(PrivateMessageConsts), nameof(PrivateMessageConsts.ContentMaxLength))]
        [DisplayName("PrivateMessageContent")]
        public string Content { get; set; }

        public ExtraPropertyDictionary ExtraProperties { get; set; } = new();
    }
}
