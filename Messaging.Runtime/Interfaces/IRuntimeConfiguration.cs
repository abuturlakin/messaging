﻿namespace Messaging.Runtime.Interfaces
{
    public interface IRuntimeConfiguration
    {
        int QueueCapacity { get; set; }

        int RunInterval { get; set; }
    }
}