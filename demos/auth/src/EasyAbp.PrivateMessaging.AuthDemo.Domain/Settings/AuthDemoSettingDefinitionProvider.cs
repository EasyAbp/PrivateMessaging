using EasyAbp.PrivateMessaging.AuthDemo.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace EasyAbp.PrivateMessaging.AuthDemo.Settings;

public class AuthDemoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AlphaSettings.MySetting1));

        //Gridin son filtre ayarlarını anımsa
        context.Add(new SettingDefinition(AuthDemoSettings.RememberGridFilterState, "false", L("DisplayName:EasyAbp.PrivateMessaging.RememberGridFilterState"), L("Description:EasyAbp.PrivateMessaging.RememberGridFilterState")));
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AuthDemoResource>(name);
    }
}
