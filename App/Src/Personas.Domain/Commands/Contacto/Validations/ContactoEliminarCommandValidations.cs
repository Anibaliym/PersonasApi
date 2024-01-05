using Personas.Domain.Commands.Contacto.Commands;

namespace Personas.Domain.Commands.Contacto.Validations
{
    public class ContactoEliminarCommandValidations : ContactoValidation<ContactoEliminarCommand>
    {
        public ContactoEliminarCommandValidations()
        {
            ValidaId();
        }
    }
}
