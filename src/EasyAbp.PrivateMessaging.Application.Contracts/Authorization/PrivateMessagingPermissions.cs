using Volo.Abp.Reflection;

namespace EasyAbp.PrivateMessaging.Authorization
{
    public class PrivateMessagingPermissions
    {
        public const string GroupName = "PrivateMessaging";
        
        public class PrivateMessages
        {
            public const string Default = GroupName + ".PrivateMessage";
            
            public const string Create = Default + ".Create";
            
            public const string SetRead = Default + ".SetRead";
            
            public const string Delete = Default + ".Delete";
        }
        
        public class PrivateMessageNotifications
        {
            public const string Default = GroupName + ".PrivateMessageNotification";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(PrivateMessagingPermissions));
        }
    }
}