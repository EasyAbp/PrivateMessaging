namespace EasyAbp.PrivateMessaging
{
    public static class PrivateMessagingDbProperties
    {
        public static string DbTablePrefix { get; set; } = "PrivateMessaging";

        public static string DbSchema { get; set; } = "PM";

        public const string ConnectionStringName = "PrivateMessaging";
    }
}
