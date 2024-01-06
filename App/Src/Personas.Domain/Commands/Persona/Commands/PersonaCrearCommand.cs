using Personas.Domain.Commands.Persona.Validations;

namespace Personas.Domain.Commands.Persona.Commands
{
    public class PersonaCrearCommand : PersonaCommand
    {
        public PersonaCrearCommand(string rut, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string genero)
        {
            Rut = rut;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            FechaNacimiento = fechaNacimiento;
            Genero = genero;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new PersonaCrearCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
