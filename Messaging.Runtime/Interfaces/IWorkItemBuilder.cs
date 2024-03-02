namespace Messaging.Runtime.Interfaces
{
    public interface IWorkItemBuilder
    {
        ValueTask BuildWorkItemAsync(CancellationToken cancellationToken, Message message);
    }
}