using System.Data.Entity;

using Messaging.Data.Interfaces;
using Messaging.Data.Specifications;

namespace Messaging.Data.Implementation
{
    public class MessageService(
        IDataContext context
    ) : IMessageService
    {
        private readonly IDbSet<Message> _messages = context.Messages;

        public Message Get(MessageGetSpec spec)
        {
            if (spec.Id.HasValue)
                return _messages.Single(m => m.ReferenceId == spec.Id.Value);
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

        public async Task SaveAsync(Message message) {
            await context.SaveChangesAsync();
        }
    }
}
