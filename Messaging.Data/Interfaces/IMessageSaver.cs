using Messaging.Common.Interfaces;
using Messaging.Data.Specifications;

namespace Messaging.Data.Interfaces
{
    public interface IMessageSaver : IUnitOfWork<MessageSaverSpec> {}
}
