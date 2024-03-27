using System.Text;

using Messaging.Web.Controllers;
using Vonage.Messaging;

namespace Messaging.Web.Extensions;

internal static class LoggingExtensions
{
    internal static void Log(this ILogger<IntegrationController> logger, InboundSms info)
    {
        var builder = new StringBuilder();
        builder.Append($"Inbound message");
        builder.AppendLine($"Message Id: {info.MessageId}");
        builder.AppendLine($"To: {info.Msisdn}");
        builder.AppendLine($"From: {info.To}");
        builder.AppendLine($"Time: {info.MessageTimestamp}");
        builder.AppendLine($"Text: {info.Text}");
        logger.LogInformation(builder.ToString());
    }

    internal static void Log(this ILogger<IntegrationController> logger, DeliveryReceipt info)
    {
        var builder = new StringBuilder();
        builder.Append($"Delivery receipt");
        builder.AppendLine($"Message Id: {info.MessageId}");
        builder.AppendLine($"To: {info.Msisdn}");
        builder.AppendLine($"From: {info.To}");
        builder.AppendLine($"Time: {info.MessageTimestamp}");
        logger.LogInformation(builder.ToString());
    }
}
