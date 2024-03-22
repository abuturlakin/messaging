using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Messaging.Service.Interfaces;
using Messaging.Service.Implementation;
using Messaging.Runtime.Interfaces;
using Messaging.Runtime.Implementation;
using Messaging.Client.Implementation;
using Messaging.Client.Interfaces;
using Messaging.Data.Interfaces;
using Messaging.Data.Implementation;

namespace Messaging.Host
{
    internal static partial class Application
    {
        private static void RegisterDependencies(
            HostApplicationBuilder builder, 
            RuntimeConfiguration configuration, 
            VonageConfiguration vonageConfiguration
        )
        {
            builder.Services
                // configuration
                .AddSingleton<IRuntimeConfiguration, RuntimeConfiguration>(_ => configuration)
                .AddSingleton<IVonageConfiguration, VonageConfiguration>(_ => vonageConfiguration)

                // data context
                .AddTransient<IDataContext, MemoryDataContext>()

                // data access
                .AddTransient<IMessageService, MessageService>()
                .AddTransient<IMessageSaver, MessageSaver>()

                // workflow
                .AddSingleton<QueueMonitor>()
                .AddHostedService<QueuedHostedService>()
                .AddTransient<IWorkItemBuilder, WorkItemBuilder>()
                .AddTransient<IMessageSender, MessageSender>()
                .AddTransient<IQueueSourceData, QueueSourceData>()
                .AddSingleton<IBackgroundTaskQueue>(_ =>
                {
                    return new DefaultBackgroundTaskQueue(configuration.QueueCapacity);
                })

                // delivery service
                //.AddTransient<IMessageDeliveryService, MessageDeliveryServiceMock>();
                //.AddSingleton<IMessageDeliveryService, MessageDeliveryServiceTwilio>();
                .AddSingleton<IMessageDeliveryService, MessageDeliveryServiceVonage>();
        }
    }
}
