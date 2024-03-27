using Microsoft.AspNetCore.Mvc;

using Vonage.Messaging;

using Messaging.Web.Extensions;

namespace Messaging.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class IntegrationController(
    ILogger<IntegrationController> logger
) : ControllerBase
{
    [HttpGet("/webhooks/inbound")]
    public IActionResult Inbound()
    {
        var info = Request.Query.ToModel<InboundSms>();
#warning Reply text comes back... Logic can detect reply type...
        logger.Log(info);
        return Ok();
    }

    [HttpGet("/webhooks/delivery")]
    public IActionResult Delivery()
    {
        var info = Request.Query.ToModel<DeliveryReceipt>();
        logger.Log(info);
        return Ok();
    }
}
