using System.Data.Entity;

using Messaging.Data.Interfaces;

namespace Messaging.Data.Implementation
{
    public class MemoryDataContext : IDataContext
    {
        public MemoryDataContext()
        {
            Messages = new MemoryDbSet<Message>()
            {
                Message.Mock(1), Message.Mock(1), Message.Mock(1), Message.Mock(1), Message.Mock(1),
                Message.Mock(2), Message.Mock(2), Message.Mock(2), Message.Mock(2), Message.Mock(2),
                Message.Mock(3), Message.Mock(3), Message.Mock(3), Message.Mock(3), Message.Mock(3),
                Message.Mock(4), Message.Mock(4), Message.Mock(4), Message.Mock(4), Message.Mock(4),
                Message.Mock(5), Message.Mock(5), Message.Mock(5), Message.Mock(5), Message.Mock(5)
            };
        }

        public IDbSet<Message> Messages { get; set; }

        public async Task SaveChangesAsync()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(100));
        }
    }
}
