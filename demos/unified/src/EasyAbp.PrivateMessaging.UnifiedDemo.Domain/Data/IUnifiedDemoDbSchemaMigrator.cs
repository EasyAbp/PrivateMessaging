using System.Threading.Tasks;

namespace EasyAbp.PrivateMessaging.UnifiedDemo.Data;

public interface IUnifiedDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
