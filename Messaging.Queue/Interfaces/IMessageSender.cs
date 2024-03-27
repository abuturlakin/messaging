using Messaging.Common.Interfaces;
using Messaging.Queue.Specifications;

namespace Messaging.Queue.Interfaces
{
    public interface IMessageSender : IUnitOfWork<MessageSenderSpec> {}
}