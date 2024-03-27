using Messaging.Queue.Interfaces;
using Messaging.Queue.Specifications;

namespace Messaging.Queue.Implementation;

public class WorkItemBuilder(
    IMessageSender messageSender
) : IWorkItemBuilder
{
    public async Task BuildWorkItemAsync(CancellationToken cancellationToken, Message message)
    {
        var spec = MessageSenderSpec.Create(message, cancellationToken);
        await messageSender.CommitAsync(spec);
    }
}