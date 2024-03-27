using Messaging.Common.Extensions;

namespace Messaging.Queue.Implementation;

internal static class MessageModelExtensions
{
    internal static string ToMessageBody(this Message message)
    {
        const string footer = "Hello from Messaging API!";

        if (message.Text.HasValue())
            return $"{message.Text}{Environment.NewLine}{footer}";

        return footer;
    }
}