using Messaging.Client.Interfaces;

using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

using Messaging.Common.Implementation;
using Messaging.Client.Specifications;

namespace Messaging.Client.Implementation;

[Obsolete]
public class MessageDeliveryServiceTwilio : UnitOfWork<MessageDeliveryServiceSpec>, IMessageDeliveryService
{
    static MessageDeliveryServiceTwilio()
    {
        TwilioClient.Init(TwilioConfiguration.AccountSid, TwilioConfiguration.AuthToken);
    }

    public override async Task ProcessAsync(MessageDeliveryServiceSpec spec)
    {
        await MessageResource.CreateAsync(
            //to: new PhoneNumber(spec.Message.Phone),
            to: new PhoneNumber(TwilioConfiguration.TwilioVirtual),
            from: new PhoneNumber(TwilioConfiguration.Twilio),
            body: spec.Body
        );
    }
}
