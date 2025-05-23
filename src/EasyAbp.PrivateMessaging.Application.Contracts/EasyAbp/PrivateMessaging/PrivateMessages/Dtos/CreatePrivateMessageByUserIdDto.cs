﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace EasyAbp.PrivateMessaging.PrivateMessages.Dtos
{
    public class CreatePrivateMessageByUserIdDto : ExtensibleObject
    {
        [Required]
        [DisplayName("PrivateMessageToUserId")]
        public Guid ToUserId { get; set; }

        [Required]
        [DynamicMaxLength(typeof(PrivateMessageConsts), nameof(PrivateMessageConsts.TitleMaxLength))]
        [DisplayName("PrivateMessageTitle")]
        public string Title { get; set; }

        [DynamicMaxLength(typeof(PrivateMessageConsts), nameof(PrivateMessageConsts.ContentMaxLength))]
        [DisplayName("PrivateMessageContent")]
        public string Content { get; set; }

        [DynamicMaxLength(typeof(PrivateMessageConsts), nameof(PrivateMessageConsts.CategoryMaxLength))]
        [DisplayName("PrivateMessageCategory")]
        public string Category { get; set; }
    }
}
