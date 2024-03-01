namespace Messaging
{
    public class Message
    {
        public Message()
        {
            Id = Guid.NewGuid();
            Status = MessageStatus.NotProcessed;
        }

        public Guid Id { get; set; }

        public MessageStatus Status { get; set; }
    }
}
