using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.Users
{
    public interface IPmUserLookupService : IUserLookupService<PmUser>
    {
        Task<IReadOnlyList<PmUser>> GetListByIdsAsync(IEnumerable<Guid> ids);
    }
}