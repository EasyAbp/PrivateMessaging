using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public class PrivateMessageNotification : AggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid UserId { get; protected set; }
        
        public virtual Guid PrivateMessageId { get; protected set; }

        protected PrivateMessageNotification()
        {
            
        }

        public PrivateMessageNotification(
            Guid id,
            Guid userId,
            Guid privateMessageId) : base(id)
        {
            UserId = userId;
            PrivateMessageId = privateMessageId;
        }
    }
}