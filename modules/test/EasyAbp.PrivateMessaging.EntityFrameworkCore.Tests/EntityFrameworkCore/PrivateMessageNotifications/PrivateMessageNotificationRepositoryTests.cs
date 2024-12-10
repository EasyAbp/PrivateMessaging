using System;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.PrivateMessaging.EntityFrameworkCore.PrivateMessageNotifications
{
    public class PrivateMessageNotificationRepositoryTests : PrivateMessagingEntityFrameworkCoreTestBase
    {
        private readonly IRepository<PrivateMessageNotification, Guid> _privateMessageNotificationRepository;

        public PrivateMessageNotificationRepositoryTests()
        {
            _privateMessageNotificationRepository = GetRequiredService<IRepository<PrivateMessageNotification, Guid>>();
        }

        [Fact]
        public virtual async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
    }
}
