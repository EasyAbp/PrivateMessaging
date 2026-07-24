using EasyAbp.PrivateMessaging.PrivateMessages;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications.Dtos;
using EasyAbp.PrivateMessaging.Users.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PrivateMessageToPrivateMessageDtoMapper : MapperBase<PrivateMessage, PrivateMessageDto>
    {
        [MapperIgnoreTarget(nameof(PrivateMessageDto.FromUser))]
        [MapperIgnoreTarget(nameof(PrivateMessageDto.ToUser))]
        public override partial PrivateMessageDto Map(PrivateMessage source);

        [MapperIgnoreTarget(nameof(PrivateMessageDto.FromUser))]
        [MapperIgnoreTarget(nameof(PrivateMessageDto.ToUser))]
        public override partial void Map(PrivateMessage source, PrivateMessageDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PrivateMessageNotificationToPrivateMessageNotificationDtoMapper
        : MapperBase<PrivateMessageNotification, PrivateMessageNotificationDto>
    {
        public override partial PrivateMessageNotificationDto Map(PrivateMessageNotification source);

        public override partial void Map(PrivateMessageNotification source, PrivateMessageNotificationDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class UserDataToPmUserDtoMapper : MapperBase<IUserData, PmUserDto>
    {
        [MapperIgnoreTarget(nameof(PmUserDto.ExtraProperties))]
        public override partial PmUserDto Map(IUserData source);

        [MapperIgnoreTarget(nameof(PmUserDto.ExtraProperties))]
        public override partial void Map(IUserData source, PmUserDto destination);
    }
}
