using MediatR;
using Personas.Domain.Events.Direccion.Events;

namespace Personas.Domain.Events.Direccion.Handlers
{
    public partial class DireccionEliminarEventHandler : INotificationHandler<DireccionEliminarEvent>
    {
        public Task Handle(DireccionEliminarEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
