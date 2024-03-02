using Microsoft.Extensions.Logging;

using Messaging.Runtime.Implementation;
using Messaging.Service.Interfaces;
using Messaging.Common;

namespace Messaging.Service.Implementation;

public class MessageSender
(
    ILogger<QueueMonitor> logger,
    IMessageService messageService
) : UnitOfWork<MessageSenderSpec>, IMessageSender
{
    public override async ValueTask ProcessAsync(MessageSenderSpec spec)
    {
        var message = spec.Message;

        try
        {

            logger.LogInformation($"Start sending message {message.Id} from batch {message.BatchNumber}.");

            await Task.Delay(TimeSpan.FromSeconds(1), spec.CancellationToken);

            message.Status = MessageStatus.Processed;


            logger.LogInformation($"Completed sending message {message.Id} from batch {message.BatchNumber}.");
        }
        catch (Exception)
        {
            message.Status = MessageStatus.Failed;

            throw;
        }

        await messageService.SaveAsync(message);
    }
}
