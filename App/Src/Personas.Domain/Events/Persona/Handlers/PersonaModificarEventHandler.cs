using MediatR;
using Personas.Domain.Events.Persona.Events;

namespace Personas.Domain.Events.Persona.Handlers
{
    public partial class PersonaModificarEventHandler : INotificationHandler<PersonaModificarEvent>
    {
        public Task Handle(PersonaModificarEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }
    }
}
