namespace EasyAbp.PrivateMessaging
{
    public static class PrivateMessagingDbProperties
    {
        public static string DbTablePrefix { get; set; } = "PrivateMessaging";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "PrivateMessaging";
    }
}
