using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.PrivateMessaging.EntityFrameworkCore;

namespace EasyAbp.PrivateMessaging.MainDemo.SqlServer.EntityFrameworkCore;

/* This DbContext is only used for database migrations.
     * It is not used on runtime. See LayoutDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
public class MainDemoMigrationsDbContext(DbContextOptions<MainDemoMigrationsDbContext> options)
    : AbpDbContext<MainDemoMigrationsDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Configure your own tables/entities inside the ConfigureLayout method */

        builder.ConfigurePrivateMessaging();
    }
}