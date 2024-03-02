namespace Messaging.Common
{
    public interface IUnitOfWork<TContext> where TContext : class
    {
        void Commit(TContext context);

        ValueTask CommitAsync(TContext context);
    }
}