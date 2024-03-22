using Vonage;
using Vonage.Request;
using Vonage.Messaging;

using Messaging.Client.Interfaces;
using Messaging.Common.Implementation;

namespace Messaging.Client.Implementation;

public class MessageDeliveryServiceVonage(
    IVonageConfiguration configuration
) : UnitOfWork<MessageDeliveryServiceSpec>, IMessageDeliveryService
{
    public override async Task ProcessAsync(MessageDeliveryServiceSpec spec)
    {
        var credentials = Credentials.FromApiKeyAndSecret(
            configuration.VonageApiKey,
            configuration.VonageApiSecret
            );

        var vonageClient = new VonageClient(credentials);
        var response = await vonageClient.SmsClient.SendAnSmsAsync(new SendSmsRequest
        {
            To = configuration.ToNumber,
            From = configuration.VonageBrandName,
            Text = spec.Body
        });
    }
}
