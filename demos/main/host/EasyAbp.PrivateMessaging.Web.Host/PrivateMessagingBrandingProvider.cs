using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EasyAbp.PrivateMessaging
{
    [Dependency(ReplaceServices = true)]
    public class PrivateMessagingBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "PrivateMessaging";
    }
}
