using EasyAbp.PrivateMessaging.PrivateMessages;
using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos
{

    [Serializable]
    public class GetPrivateMessageNotificationInput : PagedAndSortedResultRequestDto
    {
        [DynamicMaxLength(typeof(PrivateMessageConsts), nameof(PrivateMessageConsts.CategoryMaxLength))]
        [DisplayName("PrivateMessageCategory")]
        public string Category { get; set; } = null;
    }
}
