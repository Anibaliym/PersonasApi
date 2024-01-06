using Personas.Domain.Commands.Direccion.Commands;

namespace Personas.Domain.Commands.Direccion.Validations
{
    public class DireccionEliminarCommandValidations : DireccionValidation<DireccionEliminarCommand>
    {
        public DireccionEliminarCommandValidations()
        {
            ValidaId();
        }
    }
}
