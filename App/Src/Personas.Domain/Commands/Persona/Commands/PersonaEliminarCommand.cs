using Personas.Domain.Commands.Persona.Validations;

namespace Personas.Domain.Commands.Persona.Commands
{
    public class PersonaEliminarCommand : PersonaCommand
    {
        public PersonaEliminarCommand(Guid id) {
            Id = id;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new PersonaEliminarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }

    }
}
