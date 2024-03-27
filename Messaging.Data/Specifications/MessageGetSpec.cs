namespace Messaging.Data.Specifications
{
    public class MessageGetSpec
    {
        private MessageGetSpec() { }

        public Guid? Id { get; set; }

        public int? PageSize { get; set; }

        public MessageStatus? Status { get; set; }

        public Func<Message, int> OrderBy { get; set; }

        public static MessageGetSpec NonProcessedSpec(int pageSize)
        {
            return StatusSpec(
                MessageStatus.NonProcessed,
                pageSize,
                m => m.BatchNumber
            );
        }

        public static MessageGetSpec StatusSpec(
            MessageStatus status,
            int pageSize,
            Func<Message, int> orderBy
        )
        {
            return new MessageGetSpec
            {
                Status = status,
                PageSize = pageSize,
                OrderBy = orderBy
            };
        }
    }
}
