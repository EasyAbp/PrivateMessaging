using System;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging.MongoDB
{
    [DependsOn(
        typeof(PrivateMessagingTestBaseModule),
        typeof(PrivateMessagingMongoDbModule)
        )]
    public class PrivateMessagingMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
            });
        }
    }
}