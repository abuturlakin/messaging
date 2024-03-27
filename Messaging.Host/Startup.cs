using Microsoft.Extensions.Hosting;

using Messaging.Configuration.Extensions;

namespace Messaging.Service;

internal static partial class Application
{
    internal static IHost Start(string[] args)
    {
        return Host
            .CreateApplicationBuilder(args)
            .RegisterDependencies()
            .Build();
    }
}