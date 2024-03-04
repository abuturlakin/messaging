namespace Messaging
{
    public class Message
    {
        public Guid Id { get; set; }

        public int BatchNumber { get; private set; }

        public MessageStatus Status { get; set; }

        public string Phone { get; set; }

        public static Message Mock(int batchNumber)
        {
            return new Message
            {
                Id = Guid.NewGuid(),
                Status = MessageStatus.NonProcessed,
                Phone = "7034791762",
                BatchNumber = batchNumber
            };
        }
    }
}
