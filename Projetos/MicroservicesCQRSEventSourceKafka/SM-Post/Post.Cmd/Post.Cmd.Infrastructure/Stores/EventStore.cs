using CQRS.Core.Domain;
using CQRS.Core.Events;
using CQRS.Core.Exceptions;
using CQRS.Core.Infrastructe;
using Post.Cmd.Domain.Aggregates;

namespace Post.Cmd.Infrastructure.Stores
{
  public class EventStore : IEventStore
  {
    private readonly IEventStoreRepository _eventStore;

    public EventStore(IEventStoreRepository eventStoreRepository)
    {
      _eventStore = eventStoreRepository;
    }

    public async Task<List<BaseEvent>> GetEventsAsync(Guid aggregateId)
    {
      var eventStream = await _eventStore.FindByAggregateId(aggregateId);

      if (eventStream?.Any() != false)
        throw new AggregateNotFoundException("Incorrect post ID provider");

      return eventStream
        .OrderBy(_ => _.Version)
        .Select(_ => _.EventData)
        .ToList();
    }

    public async Task SaveEventsAsync(Guid aggregateId, IEnumerable<BaseEvent> events, int expectedVersion)
    {
      var eventStream = await _eventStore.FindByAggregateId(aggregateId);

      if (expectedVersion != -1 && eventStream[^1].Version != expectedVersion)
        throw new ConcurrencyException();

      var version = expectedVersion;

      foreach (var @event in events)
      {
        version++;
        @event.Version = version;
        var eventType = @event.GetType().Name;
        var eventModel = new EventModel
        {
          TimeStamp = DateTime.Now,
          AggregateIdentifier = aggregateId,
          AggregateType = nameof(PostAggregate),
          Version = version,
          EventType = eventType,
          EventData = @event
        };

        await _eventStore.SaveAsync(eventModel);
      }
    }
  }
}