using Personas.Domain.Commands.Direccion.Validations;
using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Commands.Direccion.Commands
{
    public class DireccionEliminarCommand : DireccionCommand
    {
        public DireccionEliminarCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new DireccionEliminarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
