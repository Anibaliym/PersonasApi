using Personas.Domain.Core.Dominio;

namespace Personas.Domain.Entities
{
    public class Contacto : Entity, IAggregateRoot
    {
        public Contacto(Guid id, Guid idPersona, string celular, string email, string tipoContacto)
        {
            Id = id;
            IdPersona = idPersona;
            Celular = celular;
            Email = email;
            TipoContacto = tipoContacto;
        }

        protected Contacto() { }

        public Guid IdPersona { get; set; }
        public string Celular { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TipoContacto { get; set; } = string.Empty;
    }
}
