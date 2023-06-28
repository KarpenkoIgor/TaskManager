using System.Threading.Tasks;

namespace MyTaskManager.Data;

public interface IMyTaskManagerDbSchemaMigrator
{
    Task MigrateAsync();
}
