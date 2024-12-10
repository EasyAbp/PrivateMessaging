using System.Threading.Tasks;

namespace EasyAbp.PrivateMessaging.AuthDemo.Data;

public interface IAuthDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
