using MediatR;
using Personas.Domain.Commands.Persona.Commands;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Events.Persona.Events;

namespace Personas.Domain.Commands.Persona.Handlers
{
    public partial class PersonaCommandHandler : IRequestHandler<PersonaModificarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(PersonaModificarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var persona = new Entities.Persona(
                message.Id,
                message.Rut,
                message.Nombre,
                message.ApellidoPaterno,
                message.ApellidoMaterno,
                message.FechaNacimiento,
                message.Genero
            );

            var existePersona = await _personaRepository.BuscaPorId(message.Id);

            if (existePersona == null)
            {
                AddError($"No existe la persona con el id '{message.Id}'.");
                return CommandResponse;
            }

            persona.Rut = existePersona.Rut;

            persona.AddDomainEvent(new PersonaModificarEvent(
                persona.Id,
                persona.Rut,
                persona.Nombre,
                persona.ApellidoPaterno,
                persona.ApellidoMaterno,
                persona.FechaNacimiento,
                persona.Genero
            ));

            _personaRepository.Modificar(persona);

            CommandResponse.Data = persona;
            CommandResponse.Result = true;

            return await Commit(_personaRepository.UnitOfWork);
        }
    }
}
