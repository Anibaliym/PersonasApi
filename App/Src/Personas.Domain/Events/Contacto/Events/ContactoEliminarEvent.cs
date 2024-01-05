using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Events.Contacto.Events
{
    public class ContactoEliminarEvent : Event
    {
        public ContactoEliminarEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
