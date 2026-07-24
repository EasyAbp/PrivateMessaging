using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using EasyAbp.PrivateMessaging.Web.Pages.PrivateMessaging.PrivateMessages.PrivateMessage.InfoModels;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.PrivateMessaging.Web
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PrivateMessageDtoToCreateUpdatePrivateMessageDtoMapper
        : MapperBase<PrivateMessageDto, CreateUpdatePrivateMessageDto>
    {
        [MapperIgnoreTarget(nameof(CreateUpdatePrivateMessageDto.ToUserName))]
        public override partial CreateUpdatePrivateMessageDto Map(PrivateMessageDto source);

        [MapperIgnoreTarget(nameof(CreateUpdatePrivateMessageDto.ToUserName))]
        public override partial void Map(PrivateMessageDto source, CreateUpdatePrivateMessageDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class PrivateMessageDtoToPrivateMessageInfoModelMapper
        : MapperBase<PrivateMessageDto, PrivateMessageInfoModel>
    {
        [MapperIgnoreTarget(nameof(PrivateMessageInfoModel.FromUserName))]
        [MapperIgnoreTarget(nameof(PrivateMessageInfoModel.ToUserName))]
        public override partial PrivateMessageInfoModel Map(PrivateMessageDto source);

        [MapperIgnoreTarget(nameof(PrivateMessageInfoModel.FromUserName))]
        [MapperIgnoreTarget(nameof(PrivateMessageInfoModel.ToUserName))]
        public override partial void Map(PrivateMessageDto source, PrivateMessageInfoModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreatePrivateMessageInfoModelToCreateUpdatePrivateMessageDtoMapper
        : MapperBase<CreatePrivateMessageInfoModel, CreateUpdatePrivateMessageDto>
    {
        [MapperIgnoreTarget(nameof(CreateUpdatePrivateMessageDto.ExtraProperties))]
        public override partial CreateUpdatePrivateMessageDto Map(CreatePrivateMessageInfoModel source);

        [MapperIgnoreTarget(nameof(CreateUpdatePrivateMessageDto.ExtraProperties))]
        public override partial void Map(CreatePrivateMessageInfoModel source, CreateUpdatePrivateMessageDto destination);
    }
}
