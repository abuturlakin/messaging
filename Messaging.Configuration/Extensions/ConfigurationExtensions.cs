using Microsoft.Extensions.Configuration;

namespace Messaging.Configuration.Extensions;

public static class ConfigurationExtensions
{
    public static T AsConfiguration<T>(this IConfigurationManager configurationManager)
        where T : class
    {
        return configurationManager.GetSection(typeof(T).Name).Get<T>()!;
    }
}
