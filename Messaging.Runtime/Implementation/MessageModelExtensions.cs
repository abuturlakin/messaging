﻿namespace Messaging.Runtime.Implementation
{
    internal static class MessageModelExtensions
    {
        internal static string ToMessageBody(this Message message)
        {
            return $"Hello from Vonage Messaging API";
        }
    }
}