using Messaging.Data.Specifications;

namespace Messaging.Data.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<Message> GetItems(MessageGetSpec spec);

        Message Get(MessageGetSpec spec);

        Task SaveAsync(Message message);
    }
}