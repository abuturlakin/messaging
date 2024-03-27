using Messaging.Common.Interfaces;
using Messaging.Client.Specifications;

namespace Messaging.Client.Interfaces
{
    public interface IMessageDeliveryService : IUnitOfWork<MessageDeliveryServiceSpec> { }
}