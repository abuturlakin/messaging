namespace Messaging.Service.Implementation
{
    public class MessageGetSpec
    {
        private MessageGetSpec() { }

        public Guid? Id { get; set; }

        public int? PageSize { get; set; }

        public MessageStatus? Status { get; set; }

        public static MessageGetSpec NonProcessedSpec(int pageSize)
        {
            return MessageGetSpec.StatusSpec(MessageStatus.NonProcessed, pageSize);
        }

        public static MessageGetSpec StatusSpec(MessageStatus status, int pageSize)
        {
            return new MessageGetSpec
            {
                Status = status,
                PageSize = pageSize
            };
        }
    }
}
