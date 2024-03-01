
namespace Messaging
{
    public class MessageService : IMessageService
    {
        private static readonly IEnumerable<Message> _messages = new []
        {
            new Message(),
            new Message(),
            new Message(),
            new Message(),
            new Message()
        };

        public MessageService() {}

        public Message Get(MessageGetSpec spec)
        {
            if (spec.Id.HasValue)
                return _messages.Single(m => m.Id == spec.Id.Value);
            throw new NotSupportedException();
        }

        public IEnumerable<Message> GetItems(MessageGetSpec spec)
        {
            Func<Message, bool> predicate = m => true;

            if (spec.Status.HasValue)
                predicate = m => m.Status == spec.Status.Value;

            return _messages.Where(predicate);
        }

        public void Save(Message message) {}
    }
}
