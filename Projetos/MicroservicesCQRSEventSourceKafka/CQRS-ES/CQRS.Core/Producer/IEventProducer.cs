using CQRS.Core.Events;

namespace CQRS.Core.Producer
{
  public interface IEventProducer
  {
    Task ProducerAsync<T>(string topic, T @event) where T : BaseEvent;
  }
}