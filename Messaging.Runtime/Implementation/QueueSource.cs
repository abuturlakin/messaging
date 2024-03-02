using Messaging.Runtime.Interfaces;
using Messaging.Service.Implementation;
using Messaging.Service.Interfaces;

namespace Messaging.Runtime.Implementation;

public class QueueSource(
    IMessageService messageService,
    IRuntimeConfiguration runtimeConfiguration
) : IQueueSource
{
    public IEnumerable<Message> Provide()
    {
        var spec = MessageGetSpec.NonProcessedSpec(runtimeConfiguration.QueueCapacity);
        var messages = messageService.GetItems(spec);
        return messages;
    }
}