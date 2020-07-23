using System.Security.Principal;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.PrivateMessaging.PrivateMessages
{
    public class PrivateMessageAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, PrivateMessage>, ITransientDependency
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
            if (requirement.Name.Equals(PrivateMessagingPermissions.PrivateMessages.Default) &&
                await HasGetPermissionAsync(context, resource))
            {
                context.Succeed(requirement);
                return;
            }
            
            if (requirement.Name.Equals(PrivateMessagingPermissions.PrivateMessages.Delete) &&
                await HasDeletePermissionAsync(context, resource))
            {
                context.Succeed(requirement);
                return;
            }

            if (requirement.Name.Equals(PrivateMessagingPermissions.PrivateMessages.SetRead) &&
                await HasSetReadPermissionAsync(context, resource))
            {
                context.Succeed(requirement);
                return;
            }
            
            context.Fail();
        }

        protected virtual async Task<bool> HasGetPermissionAsync(AuthorizationHandlerContext context, PrivateMessage resource)
        {
            var currentUserId = context.User.FindUserId();
            
            return (resource.ToUserId == currentUserId || resource.CreatorId == currentUserId) &&
                   await _permissionChecker.IsGrantedAsync(context.User,
                       PrivateMessagingPermissions.PrivateMessages.Delete);
        }

        protected virtual async Task<bool> HasDeletePermissionAsync(AuthorizationHandlerContext context, PrivateMessage resource)
        {
            return resource.ToUserId == context.User.FindUserId() &&
                   await _permissionChecker.IsGrantedAsync(context.User,
                       PrivateMessagingPermissions.PrivateMessages.Delete);
        }
        
        protected virtual async Task<bool> HasSetReadPermissionAsync(AuthorizationHandlerContext context, PrivateMessage resource)
        {
            return resource.ToUserId == context.User.FindUserId() &&
                   await _permissionChecker.IsGrantedAsync(context.User,
                       PrivateMessagingPermissions.PrivateMessages.SetRead);
        }
    }
}