using Microsoft.Extensions.Hosting;

using Messaging.Common.Extensions;
using Messaging.Runtime.Implementation;
using Messaging.Client.Implementation;

namespace Messaging.Host
{
    internal static partial class Application
    {
        internal static IHost Start(string[] args)
        {
            HostApplicationBuilder builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(args);

            var configuration = builder.Configuration;
            var runtimeConfiguration = configuration.AsConfiguration<RuntimeConfiguration>();
            var vonageConfiguration = configuration.AsConfiguration<VonageConfiguration>();

            RegisterDependencies(builder, runtimeConfiguration, vonageConfiguration);

            return builder.Build();
        }
    }
}
