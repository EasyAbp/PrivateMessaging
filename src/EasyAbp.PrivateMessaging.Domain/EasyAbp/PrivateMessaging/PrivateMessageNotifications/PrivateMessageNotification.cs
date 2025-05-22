using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public class PrivateMessageNotification : AggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid UserId { get; protected set; }
        
        public virtual Guid PrivateMessageId { get; protected set; }
        
        [NotNull]
        public virtual string TitlePreview { get; protected set; }

        [CanBeNull]
        public string Category { get; set; }

        protected PrivateMessageNotification()
        {
            
        }

        public PrivateMessageNotification(
            Guid id,
            Guid? tenantId,
            Guid userId,
            Guid privateMessageId,
            [NotNull] string titlePreview,
            string category = null) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            PrivateMessageId = privateMessageId;
            TitlePreview = titlePreview;
            Category = category;
        }
    }
}