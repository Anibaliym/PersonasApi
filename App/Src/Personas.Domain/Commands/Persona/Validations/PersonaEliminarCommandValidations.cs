using Personas.Domain.Commands.Persona.Commands;

namespace Personas.Domain.Commands.Persona.Validations
{
    public class PersonaEliminarCommandValidations : PersonaValidation<PersonaEliminarCommand>
    {
        public PersonaEliminarCommandValidations() {
            ValidaId();
        }
    }
}
