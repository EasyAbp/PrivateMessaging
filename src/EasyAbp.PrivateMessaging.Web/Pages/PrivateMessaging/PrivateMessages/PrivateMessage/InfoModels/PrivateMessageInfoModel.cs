﻿using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessaging.PrivateMessages.PrivateMessage.InfoModels
{
    public class PrivateMessageInfoModel
    {
        [DisabledInput]
        [Display(Name = "PrivateMessageFromUserName")]
        public string FromUserName { get; set; }

        [DisabledInput]
        [Display(Name = "PrivateMessageToUserName")]
        public string ToUserName { get; set; }
        
        [DisabledInput]
        [Display(Name = "PrivateMessageCreationTime")]
        public DateTime CreationTime { get; set; }
        
        [DisabledInput]
        [Display(Name = "PrivateMessageTitle")]
        public string Title { get; set; }

        [DisabledInput]
        [TextArea(Rows = 4)]
        [Display(Name = "PrivateMessageContent")]
        public string Content { get; set; }

        [DisabledInput]
        [Display(Name = "PrivateMessageCategory")]
        public string Category { get; set; }
    }
}