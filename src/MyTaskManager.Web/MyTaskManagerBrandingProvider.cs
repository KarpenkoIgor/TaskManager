using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MyTaskManager.Web;

[Dependency(ReplaceServices = true)]
public class MyTaskManagerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MyTaskManager";
}
