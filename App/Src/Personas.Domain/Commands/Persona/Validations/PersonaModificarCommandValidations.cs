using Personas.Domain.Commands.Persona.Commands;

namespace Personas.Domain.Commands.Persona.Validations
{
    public class PersonaModificarCommandValidations : PersonaValidation<PersonaModificarCommand>
    {
        public PersonaModificarCommandValidations()
        {
            ValidaId();
            ValidaNombre();
            ValidaApellidoPaterno();
            ValidaApellidoMaterno();
            ValidaFechaNacimiento();
            ValidaGenero();
        }
    }
}
