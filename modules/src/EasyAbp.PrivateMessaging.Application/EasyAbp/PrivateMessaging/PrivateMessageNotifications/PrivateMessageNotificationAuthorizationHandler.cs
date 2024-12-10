using System.Security.Principal;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Volo.Abp.Authorization.Permissions;

namespace EasyAbp.PrivateMessaging.PrivateMessageNotifications
{
    public class PrivateMessageNotificationAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, PrivateMessageNotification>
    {
        private readonly IPermissionChecker _permissionChecker;

        public PrivateMessageNotificationAuthorizationHandler(
            IPermissionChecker permissionChecker)
        {
            _permissionChecker = permissionChecker;
        }
        
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PrivateMessageNotification resource)
        {
            if (requirement.Name.Equals(PrivateMessagingPermissions.PrivateMessageNotifications.Delete) &&
                await HasDeletePermission(context, resource))
            {
                context.Succeed(requirement);
                return;
            }
        }
        
        private async Task<bool> HasDeletePermission(AuthorizationHandlerContext context, PrivateMessageNotification resource)
        {
            return resource.UserId == context.User.FindUserId() && await _permissionChecker.IsGrantedAsync(context.User,
                       PrivateMessagingPermissions.PrivateMessageNotifications.Delete);
        }
    }
}