using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Messaging.Runtime.Interfaces;

namespace Messaging.Runtime.Implementation;

public sealed class QueueMonitor(
    ILogger<QueueMonitor> logger,
    IRuntimeConfiguration runtimeConfiguration,
    IBackgroundTaskQueue taskQueue,
    IHostApplicationLifetime applicationLifetime,
    IQueueSourceData queueSourceData,
    IWorkItemBuilder workItemBuilder
)
{
    public void Start()
    {
        logger.LogInformation($"{nameof(QueueMonitor)} process is starting...");
        Task.Run(async () => await MonitorAsync());
    }

    private async ValueTask MonitorAsync()
    {
        CancellationToken cancellationToken = applicationLifetime.ApplicationStopping;
        while (!cancellationToken.IsCancellationRequested)
            await BuildWorkItemsAsync(taskQueue);
    }

    private async Task BuildWorkItemsAsync(IBackgroundTaskQueue taskQueue)
    {
        logger.LogInformation($"Loading batch...");

        var messages = queueSourceData.Enqueue();

        if (!messages.Any())
            await Hibernate();

        await ProcessTasks(messages);
    }

    private async Task ProcessTasks(IEnumerable<Message> messages)
    {
        logger.LogInformation($"Processing batch...");

        foreach (var message in messages)
            await BuildWorkItemAsync(workItemBuilder, taskQueue, message);
    }

    private async Task Hibernate()
    {
        logger.LogInformation($"No input data to process...");
        logger.LogInformation($"Pausing for {runtimeConfiguration.RunInterval} seconds...");
        await Task.Delay(TimeSpan.FromSeconds(runtimeConfiguration.RunInterval));
    }

    private static async Task BuildWorkItemAsync(
        IWorkItemBuilder workItemBuilder, 
        IBackgroundTaskQueue taskQueue, 
        Message message
    )
    {
        ValueTask workItem(CancellationToken cancellationToken) => workItemBuilder.BuildWorkItemAsync(cancellationToken, message);
        await taskQueue.QueueBackgroundWorkItemAsync(workItem);
    }
}