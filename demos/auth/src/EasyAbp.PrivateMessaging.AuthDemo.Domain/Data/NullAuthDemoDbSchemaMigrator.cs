using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.PrivateMessaging.AuthDemo.Data;

/* This is used if database provider does't define
 * IDemoDbSchemaMigrator implementation.
 */
public class NullAuthDemoDbSchemaMigrator : IAuthDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
