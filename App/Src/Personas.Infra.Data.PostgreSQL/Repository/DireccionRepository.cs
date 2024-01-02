using Microsoft.EntityFrameworkCore;
using Personas.Domain.Core.Data;
using Personas.Domain.Entities;
using Personas.Domain.Interfaces;
using Personas.Infra.Data.PostgreSQL.Context;

namespace Personas.Infra.Data.PostgreSQL.Repository
{
    public class DireccionRepository : IDireccionRepository
    {
        protected readonly PersonasContext Db;
        protected readonly DbSet<Direccion> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public DireccionRepository(PersonasContext context) {
            Db = context;
            DbSet = Db.Set<Direccion>();
        }

        public void Crear(Direccion modelo)
        {
            DbSet.Add(modelo);
        }

        public void Modificar(Direccion modelo)
        {
            DbSet.Update(modelo);
        }

        public void Eliminar(Direccion modelo)
        {
            DbSet.Remove(modelo);
        }

        public async Task<Direccion> BuscaPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Direccion> BuscaPorIdPersona(Guid idPersona)
        {
            return await DbSet.AsNoTracking().Where(c => c.IdPersona == idPersona).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
