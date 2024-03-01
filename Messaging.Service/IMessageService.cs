
namespace Messaging
{
    public interface IMessageService
    {
        IEnumerable<Message> GetItems(MessageGetSpec spec);

        Message Get(MessageGetSpec spec);

        void Save(Message message);
    }
}