using MediatR;
using Personas.Domain.Commands.Persona.Commands;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Events.Persona.Events;

namespace Personas.Domain.Commands.Persona.Handlers
{
    public partial class PersonaCommandHandler : IRequestHandler<PersonaEliminarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(PersonaEliminarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var existePersona = await _personaRepository.BuscaPorId(message.Id);

            if (existePersona == null)
            {
                AddError($"No existe la persona con el id '{message.Id}'.");
                return CommandResponse;
            }

            existePersona.AddDomainEvent(new PersonaEliminarEvent(existePersona.Id));

            _personaRepository.Eliminar(existePersona);

            CommandResponse.Data = null;
            CommandResponse.Result = true;

            return await Commit(_personaRepository.UnitOfWork);
        }
    }
}
