namespace Messaging.Runtime.Interfaces
{
    public interface IQueueSource
    {
        IEnumerable<Message> Provide();
    }
}