using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using AutoMapper;
using EasyAbp.PrivateMessaging.Web.Pages.PrivateMessaging.PrivateMessages.PrivateMessage.InfoModels;

namespace EasyAbp.PrivateMessaging.Web
{
    public class PrivateMessagingWebAutoMapperProfile : Profile
    {
        public PrivateMessagingWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<PrivateMessageDto, CreateUpdatePrivateMessageDto>();
            CreateMap<PrivateMessageDto, PrivateMessageInfoModel>();
            CreateMap<CreatePrivateMessageInfoModel, CreateUpdatePrivateMessageDto>();
        }
    }
}
