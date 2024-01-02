using Personas.Domain.Core.Data;
using Personas.Domain.Entities;

namespace Personas.Domain.Interfaces
{
    public interface IDireccionRepository : IRepository<Direccion>
    {
        void Crear(Direccion modelo);
        void Modificar(Direccion modelo);
        void Eliminar(Direccion modelo);

        Task<Direccion> BuscaPorId(Guid id);
        Task<Direccion> BuscaPorIdPersona(Guid idPersona);
    }
}
