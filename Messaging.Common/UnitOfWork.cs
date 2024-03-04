
using System.Reflection.Metadata;

namespace Messaging.Common;

public abstract class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : class
{
    public UnitOfWork() {}

    public virtual void Commit(TContext context)
    {
        try
        {
            OnStart(context);
            Process(context);
            OnSuccess(context);
        }
        catch
        {
            OnError(context);
        }
        finally
        {
            OnExecutionEnd(context);
        }
    }

    public async ValueTask CommitAsync(TContext context)
    {
        try
        {
            OnStart(context);
            await ProcessAsync(context);
            OnSuccess(context);
        }
        catch
        {
            OnError(context);
        }
        finally
        {
            await OnExecutionEndAsync(context);
        }
    }

    public virtual void Process(TContext context) {}

    public virtual async ValueTask ProcessAsync(TContext context)
    {
        await ValueTask.CompletedTask;
    }

    public virtual void OnStart(TContext context) {}

    public virtual void OnSuccess(TContext context) {}

    public virtual void OnError(TContext context) {}

    public virtual void OnExecutionEnd(TContext context){}

    public virtual async ValueTask OnExecutionEndAsync(TContext context)
    {
        await ValueTask.CompletedTask;
    }
}
