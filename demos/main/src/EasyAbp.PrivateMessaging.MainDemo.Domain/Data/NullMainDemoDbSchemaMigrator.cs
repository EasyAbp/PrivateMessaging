using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.PrivateMessaging.MainDemo.Data;

/* This is used if database provider does't define
 * IDemoDbSchemaMigrator implementation.
 */
public class NullMainDemoDbSchemaMigrator : IMainDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
