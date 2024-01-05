using MediatR;
using Personas.Domain.Commands.Contacto.Commands;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Events.Contacto.Events;

namespace Personas.Domain.Commands.Contacto.Handlers
{
    public partial class ContactoCommandHandler : IRequestHandler<ContactoModificarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(ContactoModificarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var contacto = new Entities.Contacto(message.Id, message.IdPersona, message.Celular, message.Email, message.TipoContacto);

            var existeContacto = await _contactoRepository.BuscaPorId(message.Id);

            if (existeContacto == null) {
                AddError($"No existe el contacto con el id '{message.Id}'.");
                return CommandResponse;
            }

            contacto.IdPersona = existeContacto.IdPersona;

            contacto.AddDomainEvent(new ContactoModificarEvent(
                contacto.Id, 
                contacto.IdPersona, 
                contacto.Celular, 
                contacto.Email, 
                contacto.TipoContacto
            ));

            _contactoRepository.Modificar( contacto );

            CommandResponse.Data = contacto;
            CommandResponse.Result = true;

            return await Commit(_contactoRepository.UnitOfWork);
        }
    }
}
