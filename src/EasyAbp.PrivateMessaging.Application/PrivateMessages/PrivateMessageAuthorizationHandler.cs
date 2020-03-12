using System.Security.Principal;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Volo.Abp.Authorization.Permissions;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class
        PrivateMessageAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, PrivateMessage>
    {
        private readonly IPermissionChecker _permissionChecker;

        public PrivateMessageAuthorizationHandler(
            IPermissionChecker permissionChecker)
        {
            _permissionChecker = permissionChecker;
        }
        
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PrivateMessage resource)
        {
            if (requirement.Name.Equals(CommonOperations.Delete.Name) && await HasDeletePermission(context, resource))
            {
                context.Succeed(requirement);
                return;
            }

            if (requirement.Name.Equals(PrivateMessagingPermissions.PrivateMessages.SetRead) &&
                await HasSetReadPermission(context, resource))
            {
                context.Succeed(requirement);
                return;
            }
        }

        private async Task<bool> HasDeletePermission(AuthorizationHandlerContext context, PrivateMessage resource)
        {
            return resource.ToUserId == context.User.FindUserId() &&
                   await _permissionChecker.IsGrantedAsync(context.User,
                       PrivateMessagingPermissions.PrivateMessages.Delete);
        }
        
        private async Task<bool> HasSetReadPermission(AuthorizationHandlerContext context, PrivateMessage resource)
        {
            return resource.ToUserId == context.User.FindUserId() &&
                   await _permissionChecker.IsGrantedAsync(context.User,
                       PrivateMessagingPermissions.PrivateMessages.SetRead);
        }
    }
}