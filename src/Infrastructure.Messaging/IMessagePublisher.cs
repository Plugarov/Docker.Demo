using System.Threading.Tasks;

namespace Infrastructure.Messaging
{
    public interface IMessagePublisher
    {
        Task PublishMessageAsync(string messageType, object message, string routingKey);
    }
}
