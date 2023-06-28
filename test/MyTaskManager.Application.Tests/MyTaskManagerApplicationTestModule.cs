using Volo.Abp.Modularity;

namespace MyTaskManager;

[DependsOn(
    typeof(MyTaskManagerApplicationModule),
    typeof(MyTaskManagerDomainTestModule)
    )]
public class MyTaskManagerApplicationTestModule : AbpModule
{

}
