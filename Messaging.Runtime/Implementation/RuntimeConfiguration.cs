using System.ComponentModel;

using Messaging.Runtime.Interfaces;

namespace Messaging.Runtime.Implementation
{
    public class RuntimeConfiguration : IRuntimeConfiguration
    {
        [DefaultValue(100)]
        public int QueueCapacity { get; set; }
    }
}
