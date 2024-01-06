using Personas.Domain.Commands.Direccion.Validations;

namespace Personas.Domain.Commands.Direccion.Commands
{
    public class DireccionModificarCommand : DireccionCommand
    {
        public DireccionModificarCommand(Guid id, string calle, string numero, string numeroCasaDepartamento, string comuna)
        {
            Calle = calle;
            Numero = numero;
            NumeroCasaDepartamento = numeroCasaDepartamento;
            Comuna = comuna;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new DireccionModificarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
