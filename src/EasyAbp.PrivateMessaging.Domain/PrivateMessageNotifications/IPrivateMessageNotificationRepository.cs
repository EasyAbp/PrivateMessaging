using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public interface IPrivateMessageNotificationRepository : IRepository<PrivateMessageNotification, Guid>
    {
    }
}