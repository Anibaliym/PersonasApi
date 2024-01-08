using FluentValidation;
using Personas.Domain.CommonValidators.Validators;
using Personas.Domain.Enumerations.Persona;

namespace Personas.Domain.Commands.Persona
{
    public abstract class PersonaValidation<T> : AbstractValidator<T> where T : PersonaCommand
    {
        protected void ValidaId()
        {
            RuleFor(persona => persona.Id)
                .NotEqual(Guid.Empty).WithMessage("El campo 'Id' es invalido")
                .NotEmpty().WithMessage("El campo 'Id' no puede ser vacío.");
        }

        protected void ValidaRut()
        {
            RuleFor(persona => persona.Rut).NotEmpty().WithMessage("El campo 'Rut' no puede ser vacío.");
        }

        protected void ValidaNombre()
        {
            RuleFor(persona => persona.Nombre).NotEmpty().WithMessage("El campo 'Nombre' no puede ser vacío.");
        }

        protected void ValidaApellidoPaterno()
        {
            RuleFor(persona => persona.ApellidoPaterno).NotEmpty().WithMessage("El campo 'ApellidoPaterno' no puede ser vacío.");
        }

        protected void ValidaApellidoMaterno()
        {
            RuleFor(persona => persona.ApellidoMaterno).NotEmpty().WithMessage("El campo 'ApellidoMaterno' no puede ser vacío.");
        }

        protected void ValidaFechaNacimiento()
        {
            RuleFor(persona => persona.FechaNacimiento).NotEmpty().WithMessage("El campo 'FechaNacimiento' no puede ser vacío.");
        }

        protected void ValidaGenero()
        {
            RuleFor(persona => persona.Genero)
                .NotEmpty().WithMessage("Por favor asegurese que el 'Genero' no este vacio")
                .Must(CommonValidator.ValidadorDeEnumeraciones<GeneroEnum>).WithMessage("El 'Genero' debe estar entre los valores permitidos ('MASCULINO','FEMENINO').");
        }
    }
}
