using Messaging.Common;
using Messaging.Client.Interfaces;
using Microsoft.Extensions.Logging;

using Twilio;
using Twilio.Types;

using Messaging.Client.Configuration;
using Twilio.Rest.Api.V2010.Account;

namespace Messaging.Client.Implementation;

public class MessageDeliveryServiceTwilio(
    ILogger<MessageDeliveryServiceTwilio> logger

) : UnitOfWork<MessageDeliveryServiceSpec>, IMessageDeliveryService
{
    static MessageDeliveryServiceTwilio()
    {
        TwilioClient.Init(TwilioConfiguration.AccountSid, TwilioConfiguration.AuthToken);
    }

    public override async ValueTask ProcessAsync(MessageDeliveryServiceSpec spec)
    {
        var message = spec.Message;

#if DEBUG
        var messageBody = $"sending message {message.Id} from batch {message.BatchNumber}.";
        //logger.LogInformation($"Start {messageBody}");
#endif
            await MessageResource.CreateAsync(
                to: new PhoneNumber(TwilioConfiguration.TwilioVirtual),
                from: new PhoneNumber(TwilioConfiguration.Twilio),
                body: "TEST"
            );
;

#if DEBUG
        logger.LogInformation($"Completed {messageBody}");
#endif
    }
}
