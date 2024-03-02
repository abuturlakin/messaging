using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Messaging.Service.Interfaces;
using Messaging.Service.Implementation;
using Messaging.Runtime.Interfaces;
using Messaging.Runtime.Implementation;

namespace Messaging.Host
{
    internal static partial class Application
    {
        private static void RegisterDependencies(HostApplicationBuilder builder, RuntimeConfiguration configuration)
        {
            builder.Services
                // configuration
                .AddSingleton<IRuntimeConfiguration, RuntimeConfiguration>(_ => configuration)

                // data access
                .AddTransient<IMessageService, MessageService>()
                .AddTransient<IMessageSaver, MessageSaver>()

                // workflow
                .AddSingleton<QueueMonitor>()
                .AddHostedService<QueuedHostedService>()
                .AddTransient<IWorkItemBuilder, WorkItemBuilder>()
                .AddTransient<IMessageSender, MessageSender>()
                .AddTransient<IQueueSource, QueueSource>()
                .AddSingleton<IBackgroundTaskQueue>(_ =>
                {
                    return new DefaultBackgroundTaskQueue(configuration.QueueCapacity);
                });
        }
    }
}
