using Messaging.Configuration.Interfaces;
using Messaging.Data.Interfaces;
using Messaging.Data.Specifications;
using Messaging.Queue.Interfaces;

namespace Messaging.Queue.Implementation;

public class QueueSourceData(
    IMessageService messageService,
    IMessageSaver messageSaver,
    IRuntimeConfiguration runtimeConfiguration
) : IQueueSourceData
{
    public IEnumerable<Message> Enqueue()
    {
        var spec = MessageGetSpec.NonProcessedSpec(runtimeConfiguration.QueueCapacity);
        var messages = messageService.GetItems(spec);
        EnqueueMessages(messageSaver, messages);
        return messages;
    }

    private static void EnqueueMessages(IMessageSaver messageSaver, IEnumerable<Message> messages)
    {
        foreach (var message in messages)
            EnqueueMessage(messageSaver, message);
    }

    private static void EnqueueMessage(IMessageSaver messageSaver, Message message)
    {
        message.Status = MessageStatus.Enqueued;
        messageSaver.CommitAsync(MessageSaverSpec.Create(message));
    }
}