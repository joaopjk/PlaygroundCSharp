using MediatR;
using MicroRabbit.Banking.Domain.Commads;
using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Domain.CommandsHandlers
{
    public class TranferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public TranferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            //publish event to rabbitmq
            _bus.Publish(new TransferCreatedEvent(
                    request.From,
                    request.To,
                    request.Amount
                ));
            return Task.FromResult(true);
        }
    }
}
