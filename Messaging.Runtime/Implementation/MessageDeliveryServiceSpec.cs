namespace Messaging.Runtime.Implementation
{
    public class MessageDeliveryServiceSpec
    {
        private MessageDeliveryServiceSpec() {}

        public Message Message { get; set; }

        public CancellationToken CancellationToken { get; set; }

        public static MessageDeliveryServiceSpec Create(Message message, CancellationToken cancellationToken)
        {
            return new MessageDeliveryServiceSpec()
            {
                Message = message,
                CancellationToken = cancellationToken
            };
        }
    }
}
