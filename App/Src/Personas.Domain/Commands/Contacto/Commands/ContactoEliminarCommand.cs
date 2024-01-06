using Personas.Domain.Core.Messaging;
using Personas.Domain.Commands.Contacto.Validations;

namespace Personas.Domain.Commands.Contacto.Commands
{
    public class ContactoEliminarCommand : ContactoCommand
    {
        public ContactoEliminarCommand(Guid id) {
            Id = id;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new ContactoEliminarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
