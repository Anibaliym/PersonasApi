using Personas.Domain.Commands.Persona.Commands;

namespace Personas.Domain.Commands.Persona.Validations
{
    public class PersonaCrearCommandValidations : PersonaValidation<PersonaCrearCommand>
    {
        public PersonaCrearCommandValidations()
        {
            ValidaRut();
            ValidaNombre();
            ValidaApellidoPaterno();
            ValidaApellidoMaterno();
            ValidaFechaNacimiento();
            ValidaGenero();
        }
    }
}
