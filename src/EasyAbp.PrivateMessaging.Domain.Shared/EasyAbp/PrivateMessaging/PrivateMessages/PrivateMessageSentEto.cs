using System;
using JetBrains.Annotations;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    [Serializable]
    public class PrivateMessageSentEto : ExtensibleObject, IMultiTenant
    {
        public Guid? TenantId { get; set; }
        
        public Guid PrivateMessageId { get; set; }
        
        public Guid? FromUserId { get; set; }
        
        [CanBeNull]
        public string FromUserName { get; set; }
        
        public Guid ToUserId { get; set; }
        
        [NotNull]
        public string ToUserName { get; set; }
        
        public DateTime SentTime { get; set; }
        
        [NotNull]
        public string Title { get; set; }

        [CanBeNull]
        public string Category { get; set; }

        public PrivateMessageSentEto()
        {
            ExtraProperties = new ExtraPropertyDictionary();
        }
        
        public PrivateMessageSentEto(Guid? tenantId, Guid privateMessageId, Guid? fromUserId,
            [CanBeNull] string fromUserName, Guid toUserId, [NotNull] string toUserName, DateTime sentTime,
            [NotNull] string title, [CanBeNull] string category)
        {
            TenantId = tenantId;
            PrivateMessageId = privateMessageId;
            FromUserId = fromUserId;
            FromUserName = fromUserName;
            ToUserId = toUserId;
            ToUserName = toUserName;
            SentTime = sentTime;
            Title = title;
            Category = category;

            ExtraProperties = new ExtraPropertyDictionary();
        }
    }
}