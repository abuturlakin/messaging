using Messaging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App.QueueService;

public sealed class QueueMonitor(
    IBackgroundTaskQueue taskQueue,
    ILogger<QueueMonitor> logger,
    IHostApplicationLifetime applicationLifetime,
    IMessageService messageService
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
        var messages = messageService.GetItems(MessageGetSpec.NotProcessedSpec);

        logger.LogInformation($"Loading messages to send.");

        foreach (var message in messages)
        {
            ValueTask workItem(CancellationToken cancellationToken) => BuildWorkItemAsync(cancellationToken, message);
            await taskQueue.QueueBackgroundWorkItemAsync(workItem);
        }
    }

    private async ValueTask BuildWorkItemAsync(CancellationToken cancellationToken, Message message)
    {
        logger.LogInformation($"Start sending message {message.Id}.");

        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);

        logger.LogInformation($"Completed sending message {message.Id}.");
    }
}