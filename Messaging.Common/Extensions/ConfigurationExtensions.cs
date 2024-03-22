using Microsoft.Extensions.Configuration;

namespace Messaging.Common.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T AsConfiguration<T>(this ConfigurationManager configurationManager)
            where T : class
        {
            return configurationManager.GetSection(typeof(T).Name).Get<T>()!;
        }
    }
}
