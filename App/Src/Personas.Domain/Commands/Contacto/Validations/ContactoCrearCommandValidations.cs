using Personas.Domain.Commands.Contacto.Commands;

namespace Personas.Domain.Commands.Contacto.Validations
{
    public class ContactoCrearCommandValidations : ContactoValidation<ContactoCrearCommand>
    {
        public ContactoCrearCommandValidations() {
            ValidaIdPersona(); 
            ValidaCelular();
            ValidaEmail();
            ValidaTipoContacto();
        }
    }
}
