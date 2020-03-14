using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessages.InfoModels
{
    public class PrivateMessageInfoModel
    {
        [DisabledInput]
        [Display(Name = "PrivateMessageCreatorName")]
        public string CreatorName { get; set; }

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
    }
}