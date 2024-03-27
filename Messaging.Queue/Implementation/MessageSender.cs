﻿using Microsoft.Extensions.Logging;

using Messaging.Common.Implementation;
using Messaging.Client.Specifications;
using Messaging.Client.Interfaces;
using Messaging.Data.Interfaces;
using Messaging.Data.Specifications;
using Messaging.Queue.Specifications;
using Messaging.Queue.Interfaces;

namespace Messaging.Queue.Implementation;

public class MessageSender
(
    ILogger<MessageSender> logger,
    IMessageSaver messageSaver,
    IMessageDeliveryService messageDeliveryService
) : UnitOfWork<MessageSenderSpec>, IMessageSender
{
    public override async Task ProcessAsync(MessageSenderSpec spec)
    {
        var message = spec.Message;

/*#if DEBUG
        var messageBody = $"sending message {message.ReferenceId} from batch {message.BatchNumber}.";
        //logger.LogInformation($"Start {messageBody}");
#endif
*/
        var deliverySpec = MessageDeliveryServiceSpec.Create(
            spec.Message,
            m => m.ToMessageBody(),
            spec.CancellationToken
        );

        await messageDeliveryService.CommitAsync(deliverySpec);

/*#if DEBUG
        logger.LogInformation($"Completed {messageBody}");
#endif*/
    }

    public override void OnSuccess(MessageSenderSpec spec)
    {
        spec.Message.Status = MessageStatus.Processed;
    }

    public override void OnError(MessageSenderSpec spec)
    {
        spec.Message.Status = MessageStatus.Failed;
    }

    public override async Task OnExecutionEndAsync(MessageSenderSpec spec)
    {
        var saveSpec = MessageSaverSpec.Create(spec.Message);
        await messageSaver.CommitAsync(saveSpec);
    }
}