namespace Messaging.Queue.Interfaces
{
    public interface IWorkItemBuilder
    {
        Task BuildWorkItemAsync(CancellationToken cancellationToken, Message message);
    }
}