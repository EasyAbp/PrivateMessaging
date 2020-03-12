using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public class PrivateMessageNotificationAppServiceTests : PrivateMessagingApplicationTestBase
    {
        private readonly IPrivateMessageNotificationAppService _privateMessageNotificationAppService;

        public PrivateMessageNotificationAppServiceTests()
        {
            _privateMessageNotificationAppService = GetRequiredService<IPrivateMessageNotificationAppService>();
        }

        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
