using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
