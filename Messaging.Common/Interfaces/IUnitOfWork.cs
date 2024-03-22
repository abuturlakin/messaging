namespace Messaging.Common.Interfaces
{
    public interface IUnitOfWork<TContext> where TContext : class
    {
        Task CommitAsync(TContext context);
    }
}