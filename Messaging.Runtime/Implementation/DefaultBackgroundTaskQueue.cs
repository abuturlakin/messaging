﻿using System.Threading.Channels;

using Messaging.Runtime.Interfaces;

namespace Messaging.Runtime.Implementation;

public sealed class DefaultBackgroundTaskQueue : IBackgroundTaskQueue
{
    private readonly Channel<Func<CancellationToken, Task>> _queue;

    public DefaultBackgroundTaskQueue(int capacity)
    {
        BoundedChannelOptions options = new(capacity)
        {
            FullMode = BoundedChannelFullMode.Wait
        };
        _queue = Channel.CreateBounded<Func<CancellationToken, Task>>(options);
    }

    public async Task QueueBackgroundWorkItemAsync(
        Func<CancellationToken, Task> workItem)
    {
        ArgumentNullException.ThrowIfNull(workItem);

        await _queue.Writer.WriteAsync(workItem);
    }

    public async Task<Func<CancellationToken, Task>> DequeueAsync(
        CancellationToken cancellationToken)
    {
        Func<CancellationToken, Task>? workItem =
            await _queue.Reader.ReadAsync(cancellationToken);

        return workItem;
    }

    public Task QueueBackgroundWorkItemAsync(Task valueTask)
    {
        throw new NotImplementedException();
    }
}