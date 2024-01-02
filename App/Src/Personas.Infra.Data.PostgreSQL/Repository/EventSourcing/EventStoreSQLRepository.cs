
using Microsoft.EntityFrameworkCore;
using Personas.Domain.Core.Events;
using Personas.Infra.Data.PostgreSQL.Context;

namespace Personas.Infra.Data.PostgreSQL.Repository.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly EventStoreSqlContext _context;

        public EventStoreSQLRepository(EventStoreSqlContext context) { 
            _context = context;
        }

        public async Task<IList<History>> All(Guid aggregateId)
        {
            return await (from e in _context.History where e.AggregateId == aggregateId select e).ToListAsync();
        }

        public void Store(History theEvent)
        {
            _context.History.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
