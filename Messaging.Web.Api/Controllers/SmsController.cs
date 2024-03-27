using Microsoft.AspNetCore.Mvc;

using Vonage.Messaging;
using Vonage.Utility;

namespace Messaging.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmsController : ControllerBase
    {
        [HttpGet("/webhooks/inbound-sms")]
        public IActionResult InboundSms()
        {
            var sms = WebhookParser.ParseQuery<InboundSms>(Request.Query);
            Console.WriteLine("SMS Received");
            Console.WriteLine($"Message Id: {sms.MessageId}");
            Console.WriteLine($"To: {sms.To}");
            Console.WriteLine($"From: {sms.Msisdn}");
            Console.WriteLine($"Text: {sms.Text}");
            return Ok();
        }
    }
}
