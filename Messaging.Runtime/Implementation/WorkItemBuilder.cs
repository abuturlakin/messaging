using Messaging.Runtime.Interfaces;
using Messaging.Service.Implementation;
using Messaging.Service.Interfaces;

namespace Messaging.Runtime.Implementation;

public class WorkItemBuilder(
    IMessageSender messageSender
) : IWorkItemBuilder
{
    public async ValueTask BuildWorkItemAsync(CancellationToken cancellationToken, Message message)
    {
        var spec = MessageSenderSpec.Create(cancellationToken, message);
        await messageSender.CommitAsync(spec);
    }
}