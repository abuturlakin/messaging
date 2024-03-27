namespace Messaging.Data.Specifications;

public class MessageSaverSpec
{
    private MessageSaverSpec() { }

    public required Message Message { get; set; }

    public static MessageSaverSpec Create(Message message)
    {
        return new MessageSaverSpec() { Message = message };
    }
}