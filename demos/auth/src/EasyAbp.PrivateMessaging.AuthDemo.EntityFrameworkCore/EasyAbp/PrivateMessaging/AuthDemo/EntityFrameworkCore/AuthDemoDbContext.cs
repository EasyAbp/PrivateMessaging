using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.PrivateMessaging.AuthDemo.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class AuthDemoDbContext(DbContextOptions<AuthDemoDbContext> options) : AbpDbContext<AuthDemoDbContext>(options), IAuthDemoDbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
