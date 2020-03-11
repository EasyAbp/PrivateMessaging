using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.PrivateMessaging.EntityFrameworkCore
{
    public class PrivateMessagingHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<PrivateMessagingHttpApiHostMigrationsDbContext>
    {
        public PrivateMessagingHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<PrivateMessagingHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("PrivateMessaging"));

            return new PrivateMessagingHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
