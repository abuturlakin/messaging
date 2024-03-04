using Messaging.Common.Interfaces;
using Messaging.Service.Implementation;

namespace Messaging.Service.Interfaces
{
    public interface IMessageSender : IUnitOfWork<MessageSenderSpec> {}
}