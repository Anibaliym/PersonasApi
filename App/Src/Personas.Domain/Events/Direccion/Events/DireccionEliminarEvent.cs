using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Events.Direccion.Events
{
    public class DireccionEliminarEvent : Event
    {
        public DireccionEliminarEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
