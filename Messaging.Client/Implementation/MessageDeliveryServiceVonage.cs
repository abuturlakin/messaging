using Vonage;
using Vonage.Request;
using Vonage.Messaging;

using Messaging.Client.Interfaces;
using Messaging.Common.Implementation;
using Microsoft.Extensions.Logging;

namespace Messaging.Client.Implementation;

public class MessageDeliveryServiceVonage(
    IVonageConfiguration configuration,
    ILogger<MessageDeliveryServiceVonage> logger
) : UnitOfWork<MessageDeliveryServiceSpec>, IMessageDeliveryService
{
    public override async Task ProcessAsync(MessageDeliveryServiceSpec spec)
    {
        var credentials = Credentials.FromApiKeyAndSecret(
            configuration.VonageApiKey,
            configuration.VonageApiSecret
            );

        var vonageClient = new VonageClient(credentials);
#warning Investigate how to use reponse information...
        var response = await vonageClient.SmsClient.SendAnSmsAsync(new SendSmsRequest
        {
            To = configuration.ToNumber,
            From = configuration.VonageBrandName,
            Text = spec.Body
        });
    }
}