
namespace Messaging.Common;

public abstract class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : class
{
    public UnitOfWork() {}

    public virtual void Commit(TContext context)
    {
        try
        {
            Process(context);
        }
        catch
        {
            OnError(context);
        }
    }

    public async ValueTask CommitAsync(TContext context)
    {
        try
        {
            await ProcessAsync(context);
        }
        catch
        {
            OnError(context);
        }
    }

    public virtual void Process(TContext context)
    {
        throw new NotSupportedException();
    }

    public virtual async ValueTask ProcessAsync(TContext context)
    {
        throw new NotSupportedException();
    }

    public virtual void OnError(TContext context)
    {
        throw new NotImplementedException();
    }
}
