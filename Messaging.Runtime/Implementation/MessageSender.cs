using Messaging.Service.Interfaces;
using Messaging.Client.Implementation;
using Messaging.Client.Interfaces;
using Messaging.Common.Implementation;

namespace Messaging.Service.Implementation;

public class MessageSender
(
    IMessageSaver messageSaver,
    IMessageDeliveryService messageDeliveryService
) : UnitOfWork<MessageSenderSpec>, IMessageSender
{
    public override async ValueTask ProcessAsync(MessageSenderSpec spec)
    {
        var deliverySpec = MessageDeliveryServiceSpec.Create(spec.Message, spec.CancellationToken);
        await messageDeliveryService.CommitAsync(deliverySpec);
    }

    public override void OnSuccess(MessageSenderSpec spec)
    {
        spec.Message.Status = MessageStatus.Processed;
    }

    public override void OnError(MessageSenderSpec spec)
    {
        spec.Message.Status = MessageStatus.Failed;
    }

    public override async ValueTask OnExecutionEndAsync(MessageSenderSpec spec)
    {
        var saveSpec = MessageSaverSpec.Create(spec.Message);
        await messageSaver.CommitAsync(saveSpec);
    }
}
