using Messaging.Runtime.Interfaces;

namespace Messaging.Runtime.Implementation
{
    public class RuntimeConfiguration : IRuntimeConfiguration
    {
        public int QueueCapacity { get; set; }

        public int RunInterval { get; set; }
    }
}
