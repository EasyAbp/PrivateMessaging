using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.PrivateMessaging.EntityFrameworkCore
{
    public class PrivateMessagingHttpApiHostMigrationsDbContext : AbpDbContext<PrivateMessagingHttpApiHostMigrationsDbContext>
    {
        public PrivateMessagingHttpApiHostMigrationsDbContext(DbContextOptions<PrivateMessagingHttpApiHostMigrationsDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePrivateMessaging();
        }
    }
}
