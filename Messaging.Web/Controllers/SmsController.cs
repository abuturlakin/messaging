using Microsoft.AspNetCore.Mvc;

using Vonage.Messaging;

using Messaging.Queue.Interfaces;
using Messaging.Web.Extensions;
using Messaging.Web.Models;
using Messaging.Client.Interfaces;
using Vonage.Utility;

namespace Messaging.Web.Controllers;

public class SmsController(
    IMessageSender messageSender,
    IVonageConfiguration vonageConfiguration
) : Controller
{
    public ActionResult Index()
    {
        var model = new SmsModel { To = vonageConfiguration.ToNumber };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Sms(SmsModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var spec = model.ToSpec();
                await messageSender.CommitAsync(spec);
                ViewBag.MessageId = spec.Message.Id;
            }
            catch (VonageSmsResponseException ex)
            {
                ViewBag.Error = ex.Message;
            }
        }
        return View("Index");
    }
}
