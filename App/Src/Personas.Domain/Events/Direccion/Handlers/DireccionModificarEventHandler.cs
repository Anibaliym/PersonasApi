using MediatR;
using Personas.Domain.Events.Direccion.Events;

namespace Personas.Domain.Events.Direccion.Handlers
{
    public partial class DireccionModificarEventHandler : INotificationHandler<DireccionModificarEvent>
    {
        public Task Handle(DireccionModificarEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
