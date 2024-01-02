using Personas.Domain.Core.Events;

namespace Personas.Infra.Data.PostgreSQL.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(History theEvent);
        Task<IList<History>> All(Guid aggregateId);
    }
}
