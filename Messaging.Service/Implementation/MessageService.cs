using Messaging.Service.Interfaces;

namespace Messaging.Service.Implementation
{
    public class MessageService : IMessageService
    {
        private static readonly IEnumerable<Message> _messages = new List<Message>()
        {
            new Message(1), new Message(1), new Message(1), new Message(1), new Message(1),
            new Message(2), new Message(2), new Message(2), new Message(2), new Message(2),
            new Message(3), new Message(3), new Message(3), new Message(3), new Message(3),
            new Message(4), new Message(4), new Message(4), new Message(4), new Message(4),
            new Message(5), new Message(5), new Message(5), new Message(5), new Message(5)
        };

        public MessageService() { }

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

            var query = _messages.Where(predicate);

            if (spec.PageSize.HasValue)
                query = query.Take(spec.PageSize.Value);

            return query.ToArray();
        }

        public async ValueTask SaveAsync(Message message) {
            // imitation of save to db delay...
            await Task.Delay(TimeSpan.FromMilliseconds(300));
        }
    }
}
