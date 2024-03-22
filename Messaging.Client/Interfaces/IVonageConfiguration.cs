namespace Messaging.Client.Interfaces;

public interface IVonageConfiguration
{
    string VonageApiKey { get; set; }

    string VonageApiSecret { get; set; }

    string ToNumber { get; set; }

    string VonageBrandName { get; set; }
}
