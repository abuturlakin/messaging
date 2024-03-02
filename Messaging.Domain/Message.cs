namespace Messaging
{
    public class Message
    {
        public Message()
        {
            Id = Guid.NewGuid();
            Status = MessageStatus.NonProcessed;
        }

        public Message(int batchNumber) : this()
        {
            BatchNumber = batchNumber;
        }

        public Guid Id { get; set; }

        public int BatchNumber { get; private set; }

        public MessageStatus Status { get; set; }
    }
}
