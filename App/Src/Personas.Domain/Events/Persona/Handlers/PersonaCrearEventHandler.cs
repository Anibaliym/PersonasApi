using MediatR;
using Personas.Domain.Events.Persona.Events;

namespace Personas.Domain.Events.Persona.Handlers
{
    public partial class PersonaCrearEventHandler : INotificationHandler<PersonaCrearEvent>
    {
        public Task Handle(PersonaCrearEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
