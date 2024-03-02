using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Messaging.Runtime.Interfaces;

namespace Messaging.Runtime.Implementation;

public sealed class QueueMonitor(
    ILogger<QueueMonitor> logger,
    IBackgroundTaskQueue taskQueue,
    IHostApplicationLifetime applicationLifetime,
    IQueueSource queueSource,
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
        var messages = queueSource.Provide();

        if (!messages.Any()) return;

        logger.LogInformation($"{Environment.NewLine}Loading and processing batch...");

        foreach (var message in messages)
            await BuildWorkItemAsync(workItemBuilder, taskQueue, message);
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