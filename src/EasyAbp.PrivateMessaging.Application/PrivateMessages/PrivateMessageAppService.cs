using System;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class PrivateMessageAppService : CrudAppService<PrivateMessage, PrivateMessageDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePrivateMessageDto, CreateUpdatePrivateMessageDto>,
        IPrivateMessageAppService
    {
        private readonly IPrivateMessageRepository _repository;

        public PrivateMessageAppService(IPrivateMessageRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}