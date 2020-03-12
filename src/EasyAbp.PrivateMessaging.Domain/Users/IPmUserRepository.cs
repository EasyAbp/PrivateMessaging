using System;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.Users
{
    public interface IPmUserRepository : IUserRepository<PmUser>
    {
        
    }
}