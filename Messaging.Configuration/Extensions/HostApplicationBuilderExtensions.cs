using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Messaging.Configuration.Implementation;
using Messaging.Configuration.Interfaces;
using Messaging.Client.Implementation;
using Messaging.Client.Interfaces;
using Messaging.Data.Interfaces;
using Messaging.Data.Implementation;
using Messaging.Queue.Implementation;
using Messaging.Queue.Interfaces;

namespace Messaging.Configuration.Extensions;

public static class HostApplicationBuilderExtensions
{
    public static TBuilder RegisterDependencies<TBuilder>(
        this TBuilder builder
    )
        where TBuilder : IHostApplicationBuilder
    {
        var configuration = builder.Configuration;
        var runtimeConfiguration = configuration.AsConfiguration<RuntimeConfiguration>();
        var vonageConfiguration = configuration.AsConfiguration<VonageConfiguration>();

        builder.Services
            // configuration
            .AddSingleton<IRuntimeConfiguration, RuntimeConfiguration>(_ => runtimeConfiguration)
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
                return new DefaultBackgroundTaskQueue(runtimeConfiguration.QueueCapacity);
            })

            // delivery service
            //.AddTransient<IMessageDeliveryService, MessageDeliveryServiceMock>();
            //.AddSingleton<IMessageDeliveryService, MessageDeliveryServiceTwilio>();
            .AddSingleton<IMessageDeliveryService, MessageDeliveryServiceVonage>();

        return builder;
    }
}
