namespace Messaging.Configuration.Interfaces;

public interface IRuntimeConfiguration
{
    int QueueCapacity { get; set; }

    int RunInterval { get; set; }
}