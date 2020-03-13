using EasyAbp.PrivateMessaging.PrivateMessages;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos;
using AutoMapper;
using EasyAbp.PrivateMessaging.Users;
using EasyAbp.PrivateMessaging.Users.Dtos;

namespace EasyAbp.PrivateMessaging
{
    public class PrivateMessagingApplicationAutoMapperProfile : Profile
    {
        public PrivateMessagingApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<PrivateMessage, PrivateMessageDto>();
            CreateMap<CreateUpdatePrivateMessageDto, PrivateMessage>(MemberList.Source);
            CreateMap<PrivateMessageNotification, PrivateMessageNotificationDto>();
            CreateMap<PmUser, PmUserDto>();
        }
    }
}
