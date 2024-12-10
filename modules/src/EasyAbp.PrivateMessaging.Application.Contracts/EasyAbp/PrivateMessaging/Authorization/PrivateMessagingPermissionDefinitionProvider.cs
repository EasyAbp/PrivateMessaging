using EasyAbp.PrivateMessaging.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.PrivateMessaging.Authorization
{
    public class PrivateMessagingPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var moduleGroup = context.AddGroup(PrivateMessagingPermissions.GroupName, L("Permission:PrivateMessaging"));
            
            var privateMessages = moduleGroup.AddPermission(PrivateMessagingPermissions.PrivateMessages.Default, L("Permission:PrivateMessage"));
            privateMessages.AddChild(PrivateMessagingPermissions.PrivateMessages.Create, L("Permission:Create"));
            privateMessages.AddChild(PrivateMessagingPermissions.PrivateMessages.SetRead, L("Permission:SetRead"));
            privateMessages.AddChild(PrivateMessagingPermissions.PrivateMessages.Delete, L("Permission:Delete"));
            
            var privateMessageNotifications = moduleGroup.AddPermission(PrivateMessagingPermissions.PrivateMessageNotifications.Default, L("Permission:PrivateMessageNotification"));
            privateMessageNotifications.AddChild(PrivateMessagingPermissions.PrivateMessageNotifications.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PrivateMessagingResource>(name);
        }
    }
}