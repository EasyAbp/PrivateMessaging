using EasyAbp.PrivateMessaging.PrivateMessageNotifications;
using EasyAbp.PrivateMessaging.PrivateMessages;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.PrivateMessaging.EntityFrameworkCore
{
    [DependsOn(
        typeof(PrivateMessagingDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class PrivateMessagingEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PrivateMessagingDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<PrivateMessage, PrivateMessageRepository>();
                options.AddRepository<PrivateMessageNotification, PrivateMessageNotificationRepository>();
            });
        }
    }
}
