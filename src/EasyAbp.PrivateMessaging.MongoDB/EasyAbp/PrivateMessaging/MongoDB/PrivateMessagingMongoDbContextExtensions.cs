using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.PrivateMessaging.MongoDB
{
    public static class PrivateMessagingMongoDbContextExtensions
    {
        public static void ConfigurePrivateMessaging(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new PrivateMessagingMongoModelBuilderConfigurationOptions(
                PrivateMessagingDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}