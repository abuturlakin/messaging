using Messaging.Common.Interfaces;

namespace Messaging.Common.Implementation;

public abstract class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : class
{
    public UnitOfWork() { }

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

    public async Task CommitAsync(TContext context)
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

    public virtual void Process(TContext context) { }

    public virtual async Task ProcessAsync(TContext context)
    {
        await Task.CompletedTask;
    }

    public virtual void OnStart(TContext context) { }

    public virtual void OnSuccess(TContext context) { }

    public virtual void OnError(TContext context) { }

    public virtual void OnExecutionEnd(TContext context) { }

    public virtual async Task OnExecutionEndAsync(TContext context)
    {
        await Task.CompletedTask;
    }
}
