using Personas.Domain.Commands.Direccion.Commands;

namespace Personas.Domain.Commands.Direccion.Validations
{
    public class DireccionCrearCommandValidations : DireccionValidation<DireccionCrearCommand>
    {
        public DireccionCrearCommandValidations()
        {
            ValidaIdPersona();
            ValidaCalle(); 
            ValidaNumero();
            ValidaNumeroCasaDepartamento();
            ValidaComuna();
            ValidaNumero(); 
        }
    }
}
