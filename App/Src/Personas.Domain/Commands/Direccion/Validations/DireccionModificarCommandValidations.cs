using Personas.Domain.Commands.Direccion.Commands;

namespace Personas.Domain.Commands.Direccion.Validations
{
    public class DireccionModificarCommandValidations : DireccionValidation<DireccionModificarCommand>
    {
        public DireccionModificarCommandValidations()
        {
            ValidaId();
            ValidaCalle();
            ValidaNumero();
            ValidaNumeroCasaDepartamento();
            ValidaComuna();
            ValidaNumero();
        }
    }
}
