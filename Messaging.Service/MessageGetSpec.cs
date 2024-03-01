namespace Messaging
{
    public class MessageGetSpec
    {
        private MessageGetSpec() {}

        public Guid? Id { get; set; }

        public int? PageSize { get; set; }

        public MessageStatus? Status { get; set; }

        public static MessageGetSpec NotProcessedSpec => StatusSpec(MessageStatus.NotProcessed);

        private static MessageGetSpec StatusSpec(MessageStatus status)
        {
            return new MessageGetSpec
            {
                Status = status,
#warning Bring from configuration...
                PageSize = 1000
            };
        }
    }
}
