using MediatR;
using Personas.Domain.Commands.Direccion.Commands;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Events.Direccion.Events;

namespace Personas.Domain.Commands.Direccion.Handlers
{
    public partial class DireccionCommandHandler : IRequestHandler<DireccionModificarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(DireccionModificarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var direccion = new Entities.Direccion(message.Id, message.IdPersona, message.Calle, message.Numero, message.NumeroCasaDepartamento, message.Comuna);

            var existeDireccion = await _direccionRepository.BuscaPorId(message.Id);

            if (existeDireccion == null)
            {
                AddError($"No existe la dirección con el id '{message.Id}'.");
                return CommandResponse;
            }


            direccion.Id = existeDireccion.Id;
            direccion.IdPersona = existeDireccion.IdPersona;
            direccion.Calle = message.Calle;
            direccion.Numero = message.Numero;
            direccion.NumeroCasaDepartamento = message.NumeroCasaDepartamento;
            direccion.Comuna = message.Comuna;

            direccion.AddDomainEvent(new DireccionModificarEvent(
                direccion.Id,
                direccion.IdPersona,
                direccion.Calle,
                direccion.Numero,
                direccion.NumeroCasaDepartamento,
                direccion.Comuna
            ));

            _direccionRepository.Modificar(direccion);

            CommandResponse.Data = direccion;
            CommandResponse.Result = true;

            return await Commit(_direccionRepository.UnitOfWork);
        }
    }
}
