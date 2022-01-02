using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.PrivateMessaging.Users.Dtos
{
    public class PmUserDto : ExtensibleEntityDto<Guid>
    {
        public string UserName { get; set; }

        public string Name { get; set; }
        
        public string Surname { get; set; }
    }
}