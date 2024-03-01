using App.QueueService;

using Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddSingleton<MonitorLoop>()
    .AddHostedService<QueuedHostedService>()
    .AddSingleton<IMessageService, MessageService>()

    .AddSingleton<IBackgroundTaskQueue>(_ =>
    {
        if (!int.TryParse(builder.Configuration["QueueCapacity"], out var queueCapacity))
        {
            queueCapacity = 100;
        }
        return new DefaultBackgroundTaskQueue(queueCapacity);
    });

IHost host = builder.Build();

MonitorLoop monitorLoop = host.Services.GetRequiredService<MonitorLoop>()!;
monitorLoop.StartMonitorLoop();

host.Run();