using System;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class PrivateMessageAppServiceTests : PrivateMessagingApplicationTestBase
    {
        private readonly IPrivateMessageAppService _privateMessageAppService;
        private readonly IObjectMapper _objectMapper;

        public PrivateMessageAppServiceTests()
        {
            _privateMessageAppService = GetRequiredService<IPrivateMessageAppService>();
            _objectMapper = GetRequiredService<IObjectMapper>();
        }

        [Fact]
        public virtual void Should_Map_PrivateMessageNotification_To_Dto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var tenantId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var privateMessageId = Guid.NewGuid();

            var notification = new PrivateMessageNotification(
                id,
                tenantId,
                userId,
                privateMessageId,
                titlePreview: "Hello there",
                category: "General");

            // Act
            var dto = _objectMapper.Map<PrivateMessageNotification, PrivateMessageNotificationDto>(notification);

            // Assert
            dto.Id.ShouldBe(id);
            dto.TenantId.ShouldBe(tenantId);
            dto.UserId.ShouldBe(userId);
            dto.PrivateMessageId.ShouldBe(privateMessageId);
            dto.TitlePreview.ShouldBe("Hello there");
            dto.Category.ShouldBe("General");
        }
    }
}
