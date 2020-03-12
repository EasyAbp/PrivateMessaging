using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;

namespace EasyAbp.PrivateMessaging.Users
{
    public class PmUserRepository : EfCoreUserRepositoryBase<PrivateMessagingDbContext, PmUser>, IPmUserRepository
    {
        public PmUserRepository(IDbContextProvider<PrivateMessagingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}