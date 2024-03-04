using Messaging.Client.Implementation;
using Messaging.Common.Interfaces;

namespace Messaging.Client.Interfaces
{
    public interface IMessageDeliveryService : IUnitOfWork<MessageDeliveryServiceSpec> { }
}