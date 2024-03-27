using Messaging.Configuration.Interfaces;

namespace Messaging.Configuration.Implementation;

public class RuntimeConfiguration : IRuntimeConfiguration
{
    public int QueueCapacity { get; set; }

    public int RunInterval { get; set; }
}
