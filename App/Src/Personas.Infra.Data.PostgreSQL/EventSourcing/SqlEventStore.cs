using Newtonsoft.Json;
using Personas.Domain.Core.Events;
using Personas.Domain.Core.Messaging;
using Personas.Infra.Data.PostgreSQL.Repository.EventSourcing;

namespace Personas.Infra.Data.PostgreSQL.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            // Using Newtonsoft.Json because System.Text.Json
            // is a sad joke to be considered "Done"

            // The System.Text don't know how serialize a
            // object with inherited properties, I said is sad...
            // Yes! I tried: options = new JsonSerializerOptions { WriteIndented = true };

            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new History(
                theEvent,
                serializedData,
                "NOT_ASSIGNED");

            _eventStoreRepository.Store(storedEvent);
        }

    }
}
