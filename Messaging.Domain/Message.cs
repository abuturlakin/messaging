namespace Messaging
{
    public class Message
    {
        public string Id { get; set; }

        public Guid ReferenceId { get; set; }

        [Obsolete("Test use only")]
        public int BatchNumber { get; private set; }

        public MessageStatus Status { get; set; }

        public string Phone { get; set; }

        public string Text { get; set; }
        
        public string JsonPayload { get; set; }

        public static Message Mock(int batchNumber)
        {
            return new Message
            {
                ReferenceId = Guid.NewGuid(),
                Status = MessageStatus.NonProcessed,
                Phone = "17034791762",
                BatchNumber = batchNumber
            };
        }
    }
}
