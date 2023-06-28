using MyTaskManager.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MyTaskManager.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MyTaskManagerPageModel : AbpPageModel
{
    protected MyTaskManagerPageModel()
    {
        LocalizationResourceType = typeof(MyTaskManagerResource);
    }
}
