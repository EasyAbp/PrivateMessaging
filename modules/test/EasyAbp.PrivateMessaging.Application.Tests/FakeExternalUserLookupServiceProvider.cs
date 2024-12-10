using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging;

public class FakeExternalUserLookupServiceProvider : IExternalUserLookupServiceProvider, ITransientDependency
{
    public static UserData UserData = new(
        Guid.Parse("2e701e62-0953-4dd3-910b-dc6cc93ccb0d"),
        "admin",
        "admin@abp.io"
    );

    public Task<IUserData> FindByIdAsync(Guid id, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task<IUserData> FindByUserNameAsync(string userName,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult<IUserData>(UserData);
    }

    public Task<List<IUserData>> SearchAsync(string sorting = null, string filter = null,
        int maxResultCount = 2147483647, int skipCount = 0,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult(new List<IUserData> { UserData });
    }

    public Task<long> GetCountAsync(string filter = null,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult<long>(1);
    }
}