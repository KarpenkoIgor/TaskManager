using MyTaskManager.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MyTaskManager;

[DependsOn(
    typeof(MyTaskManagerEntityFrameworkCoreTestModule)
    )]
public class MyTaskManagerDomainTestModule : AbpModule
{

}
