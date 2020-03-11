using EasyAbp.PrivateMessaging.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.PrivateMessaging.Authorization
{
    public class PrivateMessagingPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(PrivateMessagingPermissions.GroupName, L("Permission:PrivateMessaging"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PrivateMessagingResource>(name);
        }
    }
}