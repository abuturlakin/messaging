using Microsoft.Extensions.Logging;
using Messaging.Client.Interfaces;
using Messaging.Common.Implementation;

namespace Messaging.Client.Implementation;

public class MessageDeliveryServiceMock(
    ILogger<MessageDeliveryServiceMock> logger

) : UnitOfWork<MessageDeliveryServiceSpec>, IMessageDeliveryService
{
    public override async Task ProcessAsync(MessageDeliveryServiceSpec spec)
    {
        var message = spec.Message;

#if DEBUG
        var messageBody = $"sending message {message.Id} from batch {message.BatchNumber}.";
        //logger.LogInformation($"Start {messageBody}");
#endif

        await Task.Delay(TimeSpan.FromSeconds(1), spec.CancellationToken);

#if DEBUG
        logger.LogInformation($"Completed {messageBody}");
#endif
    }
}