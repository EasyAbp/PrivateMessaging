using System.Threading.Tasks;

namespace EasyAbp.PrivateMessaging.MainDemo.Data;

public interface IMainDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
