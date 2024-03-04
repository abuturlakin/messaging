using Messaging.Service.Interfaces;

namespace Messaging.Service.Implementation
{
    public class MessageService : IMessageService
    {
        private static readonly IEnumerable<Message> _messages = new List<Message>()
        {
            Message.Mock(1), Message.Mock(1), Message.Mock(1), Message.Mock(1), Message.Mock(1),
            Message.Mock(2), Message.Mock(2), Message.Mock(2), Message.Mock(2), Message.Mock(2),
            Message.Mock(3), Message.Mock(3), Message.Mock(3), Message.Mock(3), Message.Mock(3),
            Message.Mock(4), Message.Mock(4), Message.Mock(4), Message.Mock(4), Message.Mock(4),
            Message.Mock(5), Message.Mock(5), Message.Mock(5), Message.Mock(5), Message.Mock(5)
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

            if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);

            if (spec.PageSize.HasValue)
                query = query.Take(spec.PageSize.Value);

            return query.ToArray();
        }

        public async ValueTask SaveAsync(Message message) {
            // imitation of save to db delay...
            await Task.Delay(TimeSpan.FromMilliseconds(100));
        }
    }
}
