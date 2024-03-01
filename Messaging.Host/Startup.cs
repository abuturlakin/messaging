using App.QueueService;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Messaging.Host
{
    internal static class Application
    {
        internal static IHost Start(string[] args) {
            HostApplicationBuilder builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(args);

            builder.Services
                .AddSingleton<QueueMonitor>()
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

            return builder.Build();
        }
    }
}
