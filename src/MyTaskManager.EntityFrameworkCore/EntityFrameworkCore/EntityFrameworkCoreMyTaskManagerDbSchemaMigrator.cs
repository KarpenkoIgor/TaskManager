using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyTaskManager.Data;
using Volo.Abp.DependencyInjection;

namespace MyTaskManager.EntityFrameworkCore;

public class EntityFrameworkCoreMyTaskManagerDbSchemaMigrator
    : IMyTaskManagerDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMyTaskManagerDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MyTaskManagerDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MyTaskManagerDbContext>()
            .Database
            .MigrateAsync();
    }
}
