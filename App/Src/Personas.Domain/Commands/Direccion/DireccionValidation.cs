using FluentValidation;

namespace Personas.Domain.Commands.Direccion
{
    public abstract class DireccionValidation<T> : AbstractValidator<T> where T : DireccionCommand
    {
        protected void ValidaId()
        {
            RuleFor(direccion => direccion.Id)
                .NotEqual(Guid.Empty).WithMessage("El campo 'Id' es invalido")
                .NotEmpty().WithMessage("El campo 'Id' no puede ser vacío.");
        }
        protected void ValidaIdPersona()
        {
            RuleFor(direccion => direccion.IdPersona)
                .NotEqual(Guid.Empty).WithMessage("El campo 'IdPersona' es invalido")
                .NotEmpty().WithMessage("El campo 'IdPersona' no puede ser vacío.");
        }

        protected void ValidaCalle()
        {
            RuleFor(direccion => direccion.Calle).NotEmpty().WithMessage("El campo 'Calle' no puede ser vacío.");
        }

        protected void ValidaNumero()
        {
            RuleFor(direccion => direccion.Numero).NotEmpty().WithMessage("El campo 'Numero' no puede ser vacío.");
        }
        protected void ValidaNumeroCasaDepartamento()
        {
            RuleFor(direccion => direccion.NumeroCasaDepartamento).NotEmpty().WithMessage("El campo 'NumeroCasaDepartamento' no puede ser vacío.");
        }
        protected void ValidaComuna()
        {
            RuleFor(direccion => direccion.Comuna).NotEmpty().WithMessage("El campo 'Comuna' no puede ser vacío.");
        }
    }
}
