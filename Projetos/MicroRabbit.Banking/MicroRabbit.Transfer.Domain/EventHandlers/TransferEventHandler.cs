﻿using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.EventHandlers
{
  public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
  {
    public Task Handle(TransferCreatedEvent @event)
    {
      return Task.CompletedTask;
    }
  }
}
