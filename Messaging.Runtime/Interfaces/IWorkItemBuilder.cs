namespace Messaging.Runtime.Interfaces
{
    public interface IWorkItemBuilder
    {
        Task BuildWorkItemAsync(CancellationToken cancellationToken, Message message);
    }
}