using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Messaging.Runtime.Interfaces;

namespace Messaging.Runtime.Implementation;

public sealed class QueueMonitor(
    IBackgroundTaskQueue taskQueue,
    ILogger<QueueMonitor> logger,
    IHostApplicationLifetime applicationLifetime,
    IQueueSource queueSource,
    IWorkItemBuilder workItemBuilder
)
{
    public void Start()
    {
        logger.LogInformation($"{nameof(MonitorAsync)} loop is starting.");
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
        var messages = queueSource.Provide();

        if (!messages.Any()) return;

        logger.LogInformation($"Loading and processing batch...");

        foreach (var message in messages)
            await BuildWorkItemAsync(workItemBuilder, taskQueue, message);

        logger.LogInformation($"Loading and processing batch completed...");
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