using CQRS.Core.Events;

namespace CQRS.Core.Infrastructe
{
  public interface IEventStore
  {
    Task SaveEventsAsync(Guid aggregateId, IEnumerable<BaseEvent> events, int expectedVersion);
    Task<List<BaseEvent>> GetEventsAsync(Guid aggregateId);
  }
}