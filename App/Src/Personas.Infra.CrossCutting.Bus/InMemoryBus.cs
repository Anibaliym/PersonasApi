using MediatR;
using Personas.Domain.Core.Events;
using Personas.Domain.Core.Mediator;
using Personas.Domain.Core.Messaging;

namespace Personas.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            await _mediator.Publish(@event);
        }

        public async Task<CommandResponse> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
