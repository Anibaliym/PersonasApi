using MediatR;
using Personas.Domain.Commands.Contacto.Commands;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Events.Contacto.Events;

namespace Personas.Domain.Commands.Contacto.Handlers
{
    public partial class ContactoCommandHandler : IRequestHandler<ContactoCrearCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(ContactoCrearCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var contacto = new Entities.Contacto(Guid.NewGuid(), message.IdPersona, message.Celular, message.Email, message.TipoContacto);

            var existeContacto = await _contactoRepository.BuscaPorIdPersona_TipoContacto(message.IdPersona, message.TipoContacto);

            if (existeContacto != null)
            {
                AddError($"Ya existe el tipo de contacto { message.TipoContacto } para la persona con el campo 'IdPersona' '{ message.IdPersona }'. Operación Cancelada");
                return CommandResponse;
            }

            contacto.AddDomainEvent(new ContactoCrearEvent(
                contacto.Id, 
                message.IdPersona, 
                message.Celular, 
                message.Email, 
                message.TipoContacto
            ));

            _contactoRepository.Crear(contacto); 

            CommandResponse.Data = contacto;
            CommandResponse.Result = true;

            return await Commit(_contactoRepository.UnitOfWork); 
        }
    }
}
