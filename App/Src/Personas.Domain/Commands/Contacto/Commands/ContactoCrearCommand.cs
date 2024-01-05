using Personas.Domain.Commands.Contacto.Validations;
using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Commands.Contacto.Commands
{
    public class ContactoCrearCommand : ContactoCommand
    {
        public ContactoCrearCommand(Guid idPersona, string celular, string email, string tipoContacto)
        {
            IdPersona = idPersona;
            Celular = celular;
            Email = email;
            TipoContacto = tipoContacto;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new ContactoCrearCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
