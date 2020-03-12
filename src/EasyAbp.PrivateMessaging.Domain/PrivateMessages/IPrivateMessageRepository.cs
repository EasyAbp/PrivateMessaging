using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public interface IPrivateMessageRepository : IRepository<PrivateMessage, Guid>
    {
    }
}