using Messaging.Common.Implementation;
using Messaging.Data.Specifications;
using Messaging.Data.Interfaces;

namespace Messaging.Data.Implementation;

public class MessageSaver(
    IMessageService messageService
) : UnitOfWork<MessageSaverSpec>, IMessageSaver
{
    public override async Task ProcessAsync(MessageSaverSpec context)
    {
        await messageService.SaveAsync(context.Message);
    }
}
