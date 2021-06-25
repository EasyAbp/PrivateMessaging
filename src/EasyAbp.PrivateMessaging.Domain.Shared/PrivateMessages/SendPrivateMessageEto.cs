using System;
using JetBrains.Annotations;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    [Serializable]
    public class SendPrivateMessageEto : IMultiTenant
    {
        public Guid? TenantId { get; set; }
        
        public Guid? FromUserId { get; set; }
        
        public Guid ToUserId { get; set; }
        
        [NotNull]
        public string Title { get; set; }

        [CanBeNull]
        public string Content { get; set; }

        public SendPrivateMessageEto(Guid? tenantId, Guid? fromUserId, Guid toUserId, [NotNull] string title,
            [CanBeNull] string content)
        {
            TenantId = tenantId;
            FromUserId = fromUserId;
            ToUserId = toUserId;
            Title = title;
            Content = content;
        }
    }
}