using Messaging.Client.Interfaces;

namespace Messaging.Client.Implementation;

public class VonageConfiguration : IVonageConfiguration
{
    public VonageConfiguration() {}

    public string VonageApiKey { get; set; }

    public string VonageApiSecret { get; set; }

    public string ToNumber { get; set; }

    public string VonageBrandName { get; set; }
}
