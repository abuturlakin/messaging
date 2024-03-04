namespace Messaging.Common.Interfaces
{
    public interface IUnitOfWork<TContext> where TContext : class
    {
        void Commit(TContext context);

        Task CommitAsync(TContext context);
    }
}