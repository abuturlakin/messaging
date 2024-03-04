using Messaging.Common.Implementation;
using Messaging.Service.Interfaces;

namespace Messaging.Service.Implementation;

public class MessageSaver(
    IMessageService messageService
) : UnitOfWork<MessageSaverSpec>, IMessageSaver
{
    public override async Task ProcessAsync(MessageSaverSpec context)
    {
        await messageService.SaveAsync(context.Message);
    }
}
