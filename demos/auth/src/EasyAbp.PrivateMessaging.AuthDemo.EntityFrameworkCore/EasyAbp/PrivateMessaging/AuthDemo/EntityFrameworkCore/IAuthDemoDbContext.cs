using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.PrivateMessaging.AuthDemo.EntityFrameworkCore
{
    [ConnectionStringName(AuthDemoDbProperties.ConnectionStringName)]
    public interface IAuthDemoDbContext : IEfCoreDbContext
    {
    }
}
