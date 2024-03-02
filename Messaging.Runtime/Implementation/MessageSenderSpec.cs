namespace Messaging.Service.Implementation;

public class MessageSenderSpec
{
    private MessageSenderSpec() {}

    public Message Message { get; set; }

    public CancellationToken CancellationToken { get; set; }

    public static MessageSenderSpec Create(CancellationToken cancellationToken, Message message)
    {
        return new MessageSenderSpec
        {
            CancellationToken = cancellationToken,
            Message = message
        };
    }
}
