using Messaging.Data.Specifications;

namespace Messaging.Queue.Interfaces;

public interface IQueueSourceData
{
    IEnumerable<Message> Enqueue();
}