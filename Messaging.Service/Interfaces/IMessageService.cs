using Messaging.Service.Implementation;

namespace Messaging.Service.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<Message> GetItems(MessageGetSpec spec);

        Message Get(MessageGetSpec spec);

        Task SaveAsync(Message message);
    }
}