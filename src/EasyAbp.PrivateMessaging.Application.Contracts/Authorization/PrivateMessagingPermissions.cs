using Volo.Abp.Reflection;

namespace EasyAbp.PrivateMessaging.Authorization
{
    public class PrivateMessagingPermissions
    {
        public const string GroupName = "PrivateMessaging";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(PrivateMessagingPermissions));
        }
    }
}