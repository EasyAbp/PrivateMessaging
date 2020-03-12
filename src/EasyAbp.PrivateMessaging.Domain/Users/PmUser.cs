using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.Users
{
    public class PmUser : FullAuditedAggregateRoot<Guid>, IUser
    {
        public virtual Guid? TenantId { get; }
        
        public virtual string UserName { get; }
        
        public virtual string Email { get; }
        
        public virtual string Name { get; }
        
        public virtual string Surname { get; }
        
        public virtual bool EmailConfirmed { get; }
        
        public virtual string PhoneNumber { get; }
        
        public virtual bool PhoneNumberConfirmed { get; }
        
        protected PmUser()
        {

        }
    }
}