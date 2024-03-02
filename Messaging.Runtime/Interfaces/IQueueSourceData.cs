namespace Messaging.Runtime.Interfaces
{
    public interface IQueueSourceData
    {
        IEnumerable<Message> Enqueue();
    }
}