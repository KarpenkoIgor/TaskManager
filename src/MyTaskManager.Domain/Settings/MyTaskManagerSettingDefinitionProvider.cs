using Volo.Abp.Settings;

namespace MyTaskManager.Settings;

public class MyTaskManagerSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MyTaskManagerSettings.MySetting1));
    }
}
