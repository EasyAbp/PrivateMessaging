using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using EasyAbp.PrivateMessaging.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EasyAbp.PrivateMessaging.UnifiedDemo.SqlServer.EntityFrameworkCore;

/* This DbContext is only used for database migrations.
     * It is not used on runtime. See LayoutDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
public class UnifiedDemoMigrationsDbContext(DbContextOptions<UnifiedDemoMigrationsDbContext> options)
    : AbpDbContext<UnifiedDemoMigrationsDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureTenantManagement();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();

        /* Configure your own tables/entities inside the ConfigureLayout method */

        builder.ConfigurePrivateMessaging();
    }
}