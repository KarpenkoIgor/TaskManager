using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MyTaskManager.Data;

/* This is used if database provider does't define
 * IMyTaskManagerDbSchemaMigrator implementation.
 */
public class NullMyTaskManagerDbSchemaMigrator : IMyTaskManagerDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
