using MyTaskManager.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MyTaskManager.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MyTaskManagerController : AbpControllerBase
{
    protected MyTaskManagerController()
    {
        LocalizationResource = typeof(MyTaskManagerResource);
    }
}
