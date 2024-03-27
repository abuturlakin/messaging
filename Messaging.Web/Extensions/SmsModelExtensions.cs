using Messaging.Queue.Specifications;

namespace Messaging.Web.Extensions
{
    internal static class SmsModelExtensions
    {
        internal static MessageSenderSpec ToSpec(this Models.SmsModel model)
        {
            return MessageSenderSpec.Create(
                    new Message
                    {
                        Phone = model.To,
                        Text = model.Text
                    },
                    CancellationToken.None
                );
        }
    }
}
