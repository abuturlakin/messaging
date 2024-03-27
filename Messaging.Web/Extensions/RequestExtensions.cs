using Vonage.Utility;

namespace Messaging.Web.Extensions;

internal static class RequestExtensions
{
    internal static TModel ToModel<TModel>(this IQueryCollection query)
    {
        return WebhookParser.ParseQuery<TModel>(query);
    }
}
