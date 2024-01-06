using MediatR;
using Personas.Domain.Events.Contacto.Events;

namespace Personas.Domain.Events.Contacto.Handlers
{
    public partial class ContactoEliminarEventHandler : INotificationHandler<ContactoEliminarEvent>
    {
        public Task Handle(ContactoEliminarEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
