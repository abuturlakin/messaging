namespace Messaging.Client.Implementation
{
    public class MessageDeliveryServiceSpec
    {
        private MessageDeliveryServiceSpec() {}

        public Message Message { get; set; }

        public Func<Message, string> BodyBuilder { get; set; }

        public string Body => BodyBuilder(Message);

        public CancellationToken CancellationToken { get; set; }

        public static MessageDeliveryServiceSpec Create(
            Message message, 
            Func<Message, string> bodyBuilder, 
            CancellationToken cancellationToken
        )
        {
            return new MessageDeliveryServiceSpec()
            {
                Message = message,
                BodyBuilder = bodyBuilder,
                CancellationToken = cancellationToken
            };
        }
    }
}
