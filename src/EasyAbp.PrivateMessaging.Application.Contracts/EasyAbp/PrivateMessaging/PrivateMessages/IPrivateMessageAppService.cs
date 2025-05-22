using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public interface IPrivateMessageAppService : IApplicationService
    {
        Task<PrivateMessageDto> GetAsync(Guid id);
        
        Task<PagedResultDto<PrivateMessageDto>> GetListAsync(GetPrivateMessageListInput input);
        
        Task<PagedResultDto<PrivateMessageDto>> GetListUnreadAsync(GetPrivateMessageListInput input);
        
        Task<PagedResultDto<PrivateMessageDto>> GetListSentAsync(GetPrivateMessageListInput input);

        Task DeleteAsync(IEnumerable<Guid> ids);

        Task SetReadAsync(IEnumerable<Guid> ids);

        Task<PrivateMessageDto> CreateAsync(CreateUpdatePrivateMessageDto input);

        Task<PrivateMessageDto> CreateByUserIdAsync(CreatePrivateMessageByUserIdDto input);
    }
}