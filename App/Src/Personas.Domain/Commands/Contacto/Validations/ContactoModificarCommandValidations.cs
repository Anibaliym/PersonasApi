using Personas.Domain.Commands.Contacto.Commands;

namespace Personas.Domain.Commands.Contacto.Validations
{
    public class ContactoModificarCommandValidations : ContactoValidation<ContactoModificarCommand>
    {
        public ContactoModificarCommandValidations()
        {
            ValidaId();
            ValidaCelular();
            ValidaEmail();
            ValidaTipoContacto();
        }
    }
}
