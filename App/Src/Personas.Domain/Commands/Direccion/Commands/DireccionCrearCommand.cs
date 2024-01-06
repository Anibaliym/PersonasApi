using Personas.Domain.Commands.Direccion.Validations;
using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Commands.Direccion.Commands
{
    public class DireccionCrearCommand : DireccionCommand
    {
        public DireccionCrearCommand(Guid idPersona, string calle, string numero, string numeroCasaDepartamento, string comuna)
        {
            IdPersona = idPersona;
            Calle = calle;
            Numero = numero;
            NumeroCasaDepartamento = numeroCasaDepartamento;
            Comuna = comuna;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new DireccionCrearCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
