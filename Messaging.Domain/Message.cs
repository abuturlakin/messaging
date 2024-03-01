namespace Messaging
{
    public class Message
    {
        public Message()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public MessageStatus Status { get; set; }
    }
}
