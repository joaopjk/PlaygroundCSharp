using System.Collections;
using CQRS.Core.Events;
using System.Linq;

namespace CQRS.Core.Domain
{
  public class AggregateRoot
  {
    protected Guid _id;
    private readonly List<BaseEvent> _changes = new();

    protected Guid Id { get => _id; }

    public int Version { get; set; } = 1;
    public IEnumerable<BaseEvent> GetUncommittedChanges()
    {
      return _changes;
    }

    public void MarkChangesAsCommitted()
    {
      _changes.Clear();
    }

    private void ApplyChange(BaseEvent @event, bool isNew)
    {
      var method = this.GetType().GetMethod("Apply", new Type[] { @event.GetType() });

      if (method == null)
      {
        // throw new ArgumentNullException(
        //   nameof(method),
        //   $"The Apply method is not found in the aggregate for {@event.GetType().Name}");
        throw new Exception();
      }

      method.Invoke(this, new object[] { @event });

      if (isNew)
        _changes.Add(@event);
    }

    protected void RaiseEvent(BaseEvent @event)
    {
      ApplyChange(@event, true);
    }

    public void ReplayEvents(IEnumerable<BaseEvent> events)
    {
      foreach (var @event in events)
      {
        ApplyChange(@event, false);
      }
    }
  }
}