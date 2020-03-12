using System;
using EasyAbp.PrivateMessaging.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class PrivateMessageRepository : EfCoreRepository<PrivateMessagingDbContext, PrivateMessage, Guid>, IPrivateMessageRepository
    {
        public PrivateMessageRepository(IDbContextProvider<PrivateMessagingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}