namespace EasyAbp.PrivateMessaging
{
    public static class PrivateMessagingDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Pm";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "EasyAbpPrivateMessaging";
    }
}
