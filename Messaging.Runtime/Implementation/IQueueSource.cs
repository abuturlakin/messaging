
namespace Messaging.Runtime.Implementation
{
    public interface IQueueSource
    {
        IEnumerable<Message> Provide();
    }
}