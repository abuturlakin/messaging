namespace Messaging.Common.Interfaces
{
    public interface IUnitOfWork<TContext> where TContext : class
    {
        void Commit(TContext context);

        ValueTask CommitAsync(TContext context);
    }
}