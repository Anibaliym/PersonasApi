using MediatR;
using Personas.Domain.Commands.Contacto.Commands;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Events.Persona.Events;
using Personas.Domain.Interfaces;

namespace Personas.Domain.Commands.Contacto.Handlers
{
    public partial class ContactoCommandHandler : IRequestHandler<ContactoEliminarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(ContactoEliminarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var existeContacto = await _contactoRepository.BuscaPorId(message.Id);

            if (existeContacto == null)
            {
                AddError($"No existe el contacto con el id '{message.Id}'. Operación cancelada.");
                return CommandResponse;
            }

            existeContacto.AddDomainEvent(new PersonaEliminarEvent(existeContacto.Id));

            _contactoRepository.Eliminar(existeContacto);

            CommandResponse.Data = null;
            CommandResponse.Result = true;

            return await Commit(_contactoRepository.UnitOfWork);
        }
    }
}
