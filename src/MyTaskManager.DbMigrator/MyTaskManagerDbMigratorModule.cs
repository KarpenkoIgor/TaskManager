using MyTaskManager.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MyTaskManager.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MyTaskManagerEntityFrameworkCoreModule),
    typeof(MyTaskManagerApplicationContractsModule)
    )]
public class MyTaskManagerDbMigratorModule : AbpModule
{

}


