using MediatR;
using Personas.Domain.Commands.Direccion.Commands;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Events.Persona.Events;

namespace Personas.Domain.Commands.Direccion.Handlers
{
    public partial class DireccionCommandHandler : IRequestHandler<DireccionEliminarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(DireccionEliminarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var existeDireccion = await _direccionRepository.BuscaPorId(message.Id);

            if (existeDireccion == null)
            {
                AddError($"No existe la dirección con el id '{message.Id}'.");
                return CommandResponse;
            }

            existeDireccion.AddDomainEvent(new PersonaEliminarEvent(existeDireccion.Id));

            _direccionRepository.Eliminar(existeDireccion);

            CommandResponse.Data = null;
            CommandResponse.Result = true;

            return await Commit(_direccionRepository.UnitOfWork);
        }
    }
}
