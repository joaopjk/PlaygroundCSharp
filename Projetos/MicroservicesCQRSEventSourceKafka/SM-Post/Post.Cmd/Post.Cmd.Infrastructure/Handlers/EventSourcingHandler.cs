using CQRS.Core.Domain;
using CQRS.Core.Handlers;
using CQRS.Core.Infrastructe;
using Post.Cmd.Domain.Aggregates;

namespace Post.Cmd.Infrastructure.Handlers
{
  public class EventSourcingHandler : IEventSourcingHandler<PostAggregate>
  {
    private readonly IEventStore _eventStore;

    public EventSourcingHandler(IEventStore eventStore)
    {
      _eventStore = eventStore;
    }

    public async Task<PostAggregate> GetByIdAsync(Guid aggregateId)
    {
      var aggregate = new PostAggregate();
      var events = await _eventStore.GetEventsAsync(aggregateId);

      if (events == null || events.Count > 0) return aggregate;

      aggregate.ReplayEvents(events);
      aggregate.Version = events.Max(_ => _.Version);

      return aggregate;
    }

    public async Task SaveAsync(AggregateRoot aggregate)
    {
      await _eventStore.SaveEventsAsync(
          aggregate.Id,
          aggregate.GetUncommittedChanges(),
          aggregate.Version);
      aggregate.MarkChangesAsCommitted();
    }
  }
}