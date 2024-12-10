using EasyAbp.PrivateMessaging.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.PrivateMessaging.UnifiedDemo.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class UnifiedDemoDbContext(DbContextOptions<UnifiedDemoDbContext> options) : AbpDbContext<UnifiedDemoDbContext>(options), IUnifiedDemoDbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePrivateMessaging();
    }
}
