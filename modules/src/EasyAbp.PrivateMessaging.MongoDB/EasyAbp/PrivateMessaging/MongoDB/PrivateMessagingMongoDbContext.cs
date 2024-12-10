using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.PrivateMessaging.MongoDB
{
    [ConnectionStringName(PrivateMessagingDbProperties.ConnectionStringName)]
    public class PrivateMessagingMongoDbContext : AbpMongoDbContext, IPrivateMessagingMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigurePrivateMessaging();
        }
    }
}