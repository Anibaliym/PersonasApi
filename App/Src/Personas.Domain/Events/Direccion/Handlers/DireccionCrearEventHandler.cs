using MediatR;
using Personas.Domain.Events.Direccion.Events;

namespace Personas.Domain.Events.Direccion.Handlers
{
    public partial class DireccionCrearEventHandler : INotificationHandler<DireccionCrearEvent>
    {
        public Task Handle(DireccionCrearEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
