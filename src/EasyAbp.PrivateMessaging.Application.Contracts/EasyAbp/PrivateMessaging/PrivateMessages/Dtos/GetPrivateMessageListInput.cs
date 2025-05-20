using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;

namespace EasyAbp.PrivateMessaging.PrivateMessages.Dtos
{
    [Serializable]
    public class GetPrivateMessageListInput : PagedAndSortedResultRequestDto
    {
        [DynamicMaxLength(typeof(PrivateMessageConsts), nameof(PrivateMessageConsts.CategoryMaxLength))]
        [DisplayName("PrivateMessageCategory")]
        public string Category { get; set; } = null;
    }
}
