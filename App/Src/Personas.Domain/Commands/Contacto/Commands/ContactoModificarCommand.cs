using Personas.Domain.Commands.Contacto.Validations;
using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Commands.Contacto.Commands
{
    public class ContactoModificarCommand : ContactoCommand
    {
        public ContactoModificarCommand(Guid id, string celular, string email, string tipoContacto)
        {
            Id = id;
            Celular = celular;
            Email = email;
            TipoContacto = tipoContacto;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new ContactoModificarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
