using Personas.Domain.Commands.Persona.Validations;

namespace Personas.Domain.Commands.Persona.Commands
{
    public class PersonaModificarCommand : PersonaCommand
    {
        public PersonaModificarCommand(Guid id, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string genero)
        {
            Id = id;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            FechaNacimiento = fechaNacimiento;
            Genero = genero;

        }
        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new PersonaModificarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}