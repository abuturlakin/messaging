using Messaging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App.QueueService;

public sealed class MonitorLoop(
    IBackgroundTaskQueue taskQueue,
    ILogger<MonitorLoop> logger,
    IHostApplicationLifetime applicationLifetime,
    IMessageService messageService
)
{
    private readonly CancellationToken _cancellationToken = applicationLifetime.ApplicationStopping;

    public void StartMonitorLoop()
    {
        logger.LogInformation($"{nameof(MonitorAsync)} loop is starting.");
        Task.Run(async () => await MonitorAsync());
    }

    private async ValueTask MonitorAsync()
    {
        while (!_cancellationToken.IsCancellationRequested)
            await BuildWorkItemsAsync(taskQueue);
    }

    private async Task BuildWorkItemsAsync(IBackgroundTaskQueue taskQueue)
    {
        var messages = messageService.GetItems(MessageGetSpec.NotProcessedSpec);

        logger.LogInformation($"Loading messages to send.");

        foreach (var message in messages)
        {
            ValueTask workItem(CancellationToken token) => BuildWorkItemAsync(token, message);
            await taskQueue.QueueBackgroundWorkItemAsync(workItem);
        }
    }

    private async ValueTask BuildWorkItemAsync(CancellationToken token, Message message)
    {
        logger.LogInformation($"Start sending message {message.Id}.");

        await Task.Delay(TimeSpan.FromSeconds(1), token);

        logger.LogInformation($"Completed sending message {message.Id}.");
    }
}