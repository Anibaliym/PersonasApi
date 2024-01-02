using MediatR;
using Personas.Domain.Events.Persona.Events;

namespace Personas.Domain.Events.Persona.Handlers
{
    public partial class PersonaEliminarEventHandler : INotificationHandler<PersonaEliminarEvent>
    {
        public Task Handle(PersonaEliminarEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
