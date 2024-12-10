using System.IO;
using EasyAbp.PrivateMessaging.AuthDemo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.PrivateMessaging.AuthDemo.SqlServer.EntityFrameworkCore;

/* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
public class AuthDemoMigrationsDbContextFactory : IDesignTimeDbContextFactory<AuthDemoMigrationsDbContext>
{
    public AuthDemoMigrationsDbContext CreateDbContext(string[] args)
    {
        AuthDemoEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AuthDemoMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new AuthDemoMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EasyAbp.PrivateMessaging.AuthDemo.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
