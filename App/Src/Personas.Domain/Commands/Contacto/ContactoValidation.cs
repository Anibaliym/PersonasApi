using FluentValidation;
using Personas.Domain.Enumerations.Contacto;
using Personas.Domain.CommonValidators.Validators;

namespace Personas.Domain.Commands.Contacto
{
    public abstract class ContactoValidation<T> : AbstractValidator<T> where T : ContactoCommand
    {
        protected void ValidaId()
        {
            RuleFor(contacto => contacto.Id)
                .NotEqual(Guid.Empty).WithMessage("El campo 'Id' es invalido")
                .NotEmpty().WithMessage("El campo 'Id' no puede ser vacío.");
        }
        protected void ValidaIdPersona()
        {
            RuleFor(contacto => contacto.IdPersona)
                .NotEqual(Guid.Empty).WithMessage("El campo 'IdPersona' es invalido")
                .NotEmpty().WithMessage("El campo 'IdPersona' no puede ser vacío.");
        }

        protected void ValidaCelular()
        {
            RuleFor(contacto => contacto.Celular).NotEmpty().WithMessage("El campo 'Celular' no puede ser vacío.");
        }
        protected void ValidaEmail()
        {
            RuleFor(contacto => contacto.Email).NotEmpty().WithMessage("El campo 'Email' no puede ser vacío.");
        }
        protected void ValidaTipoContacto()
        {
            //ayanez - por revisar error
            RuleFor(contacto => contacto.TipoContacto)
                .NotEmpty().WithMessage("Por favor asegurese que el 'Genero' no este vacio")
                .Must(CommonValidator.ValidadorDeEnumeraciones<TipoContactoEnum>).WithMessage("El 'TipoContacto' debe estar entre los valores permitidos ('MASCULINO','FEMENINO').");
        }
    }
}
