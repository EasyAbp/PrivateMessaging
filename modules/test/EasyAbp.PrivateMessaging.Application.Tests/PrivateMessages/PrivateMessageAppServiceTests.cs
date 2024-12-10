using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class PrivateMessageAppServiceTests : PrivateMessagingApplicationTestBase
    {
        private readonly IPrivateMessageAppService _privateMessageAppService;

        public PrivateMessageAppServiceTests()
        {
            _privateMessageAppService = GetRequiredService<IPrivateMessageAppService>();
        }

        [Fact]
        public virtual async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
