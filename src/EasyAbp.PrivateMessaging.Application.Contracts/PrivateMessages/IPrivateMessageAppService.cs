using System;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public interface IPrivateMessageAppService :
        ICrudAppService< 
            PrivateMessageDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdatePrivateMessageDto,
            CreateUpdatePrivateMessageDto>
    {

    }
}