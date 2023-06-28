using System;
using System.Collections.Generic;
using System.Text;
using MyTaskManager.Localization;
using Volo.Abp.Application.Services;

namespace MyTaskManager;

/* Inherit your application services from this class.
 */
public abstract class MyTaskManagerAppService : ApplicationService
{
    protected MyTaskManagerAppService()
    {
        LocalizationResource = typeof(MyTaskManagerResource);
    }
}
