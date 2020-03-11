using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.PrivateMessaging
{
    [Dependency(ReplaceServices = true)]
    public class PrivateMessagingBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "PrivateMessaging";
    }
}
