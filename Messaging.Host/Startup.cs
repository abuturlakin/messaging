using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using Messaging.Runtime.Implementation;

namespace Messaging.Host
{
    internal static partial class Application
    {
        internal static IHost Start(string[] args)
        {
            HostApplicationBuilder builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(args);

            var configuration = builder.Configuration
                .GetSection(typeof(RuntimeConfiguration).Name)
                .Get<RuntimeConfiguration>()!;

            RegisterDependencies(builder, configuration);

            return builder.Build();
        }
    }
}
