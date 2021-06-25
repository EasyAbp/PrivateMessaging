using System.ComponentModel.DataAnnotations;
using EasyAbp.PrivateMessaging.PrivateMessages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Validation;

namespace EasyAbp.PrivateMessaging.Web.Pages.PrivateMessaging.PrivateMessages.PrivateMessage.InfoModels
{
    public class CreatePrivateMessageInfoModel
    {
        [Required]
        [Placeholder("PrivateMessageToUserNamePlaceholder")]
        [Display(Name = "PrivateMessageToUserName")]
        public string ToUserName { get; set; }

        [Required]
        [DynamicMaxLength(typeof(PrivateMessageConsts), nameof(PrivateMessageConsts.TitleMaxLength))]
        [Display(Name = "PrivateMessageTitle")]
        public string Title { get; set; }

        [TextArea(Rows = 4)]
        [DynamicMaxLength(typeof(PrivateMessageConsts), nameof(PrivateMessageConsts.ContentMaxLength))]
        [Display(Name = "PrivateMessageContent")]
        public string Content { get; set; }
    }
}