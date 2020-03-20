using System.ComponentModel.DataAnnotations;
using EasyAbp.PrivateMessaging.PrivateMessages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessaging.PrivateMessages.PrivateMessage.InfoModels
{
    public class CreatePrivateMessageInfoModel
    {
        [Required]
        [Placeholder("PrivateMessageToUserNamePlaceholder")]
        [Display(Name = "PrivateMessageToUserName")]
        public string ToUserName { get; set; }

        [Required]
        [MaxLength(PrivateMessageConsts.TitleMaxLength)]
        [Display(Name = "PrivateMessageTitle")]
        public string Title { get; set; }

        [TextArea(Rows = 4)]
        [MaxLength(PrivateMessageConsts.ContentMaxLength)]
        [Display(Name = "PrivateMessageContent")]
        public string Content { get; set; }
    }
}