namespace Messaging.Queue.Specifications;

public class MessageSenderSpec
{
    private MessageSenderSpec() { }

    public Message Message { get; set; }

    public CancellationToken CancellationToken { get; set; }

    public static MessageSenderSpec Create(Message message, CancellationToken cancellationToken)
    {
        return new MessageSenderSpec
        {
            CancellationToken = cancellationToken,
            Message = message
        };
    }
}
