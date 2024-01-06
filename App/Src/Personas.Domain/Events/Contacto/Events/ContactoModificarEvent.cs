using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Events.Contacto.Events
{
    public class ContactoModificarEvent : Event
    {
        public ContactoModificarEvent(Guid id, Guid idPersona, string celular, string email, string tipoContacto)
        {
            Id = id;
            IdPersona = idPersona;
            Celular = celular;
            Email = email;
            TipoContacto = tipoContacto;

            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Guid IdPersona { get; set; }
        public string Celular { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TipoContacto { get; set; } = string.Empty;
    }
}
