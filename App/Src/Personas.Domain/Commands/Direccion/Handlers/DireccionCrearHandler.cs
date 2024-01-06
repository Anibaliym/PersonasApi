using MediatR;
using Personas.Domain.Commands.Direccion.Commands;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Events.Direccion.Events;

namespace Personas.Domain.Commands.Direccion.Handlers
{
    public partial class DireccionCommandHandler : IRequestHandler<DireccionCrearCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(DireccionCrearCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var direccion = new Entities.Direccion(
                Guid.NewGuid(), 
                message.IdPersona, 
                message.Calle, 
                message.Numero, 
                message.NumeroCasaDepartamento, 
                message.Comuna
            );

            var existeDireccion = await _direccionRepository.BuscaPorId(message.IdPersona);

            if (existeDireccion != null) {
                AddError($"La dirección con el campo 'IdPersona' ({message.Id}), ya existe.");
                return CommandResponse;
            }

            direccion.AddDomainEvent(new DireccionCrearEvent(
                direccion.Id, 
                direccion.IdPersona, 
                direccion.Calle, 
                direccion.Numero, 
                direccion.NumeroCasaDepartamento, 
                direccion.Comuna
            ));

            _direccionRepository.Crear(direccion);

            CommandResponse.Data = direccion;
            CommandResponse.Result = true;

            return await Commit(_direccionRepository.UnitOfWork);
        }
    }
}
