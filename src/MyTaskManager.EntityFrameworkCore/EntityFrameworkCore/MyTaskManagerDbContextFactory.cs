using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MyTaskManager.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class MyTaskManagerDbContextFactory : IDesignTimeDbContextFactory<MyTaskManagerDbContext>
{
    public MyTaskManagerDbContext CreateDbContext(string[] args)
    {
        MyTaskManagerEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<MyTaskManagerDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));

        return new MyTaskManagerDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MyTaskManager.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
