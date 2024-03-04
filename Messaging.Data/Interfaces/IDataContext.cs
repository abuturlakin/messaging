using System.Data.Entity;

namespace Messaging.Data.Interfaces
{
    public interface IDataContext
    {
        IDbSet<Message> Messages { get; set; }

        Task SaveChangesAsync();
    }
}