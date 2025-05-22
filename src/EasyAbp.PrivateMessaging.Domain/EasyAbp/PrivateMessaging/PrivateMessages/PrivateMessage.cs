using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class PrivateMessage : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        
        public virtual Guid? FromUserId { get; protected set; }
        
        public virtual Guid ToUserId { get; protected set; }

        [NotNull]
        public virtual string Title { get; protected set; }
        
        [CanBeNull]
        public virtual string Content { get; protected set; }

        [CanBeNull]
        public virtual string Category { get; protected set; }

        public virtual DateTime? ReadTime { get; protected set; }

        protected PrivateMessage()
        {
            
        }

        internal PrivateMessage(
            Guid id,
            Guid? tenantId,
            Guid? fromUserId,
            Guid toUserId,
            [NotNull] string title,
            [CanBeNull] string content,
            string category = null) : base(id)
        {
            TenantId = tenantId;
            FromUserId = fromUserId;
            ToUserId = toUserId;
            Title = title;
            Content = content;
            Category = category;
        }

        internal void AddDistributedEvent(PrivateMessageSentEto eto)
        {
            base.AddDistributedEvent(eto);
        }

        public void TrySetReadTime(DateTime time)
        {
            if (ReadTime.HasValue)
            {
                return;
            }

            ReadTime = time;
        }

        public string GetTitlePreview()
        {
            return Title.Substring(0,
                Title.Length > PrivateMessageConsts.TitlePreviewMaxLength
                    ? PrivateMessageConsts.TitlePreviewMaxLength
                    : Title.Length);
        }
    }
}