using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace MyTaskManager;

public class MyTaskManagerWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<MyTaskManagerWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
