using Microsoft.EntityFrameworkCore;
using Personas.Domain.Core.Data;
using Personas.Domain.Entities;
using Personas.Domain.Interfaces;
using Personas.Infra.Data.PostgreSQL.Context;

namespace Personas.Infra.Data.PostgreSQL.Repository
{
    public class ContactoRepository : IContactoRepository
    {
        protected readonly PersonasContext Db;
        protected readonly DbSet<Contacto> DbSet;

        public IUnitOfWork UnitOfWork => Db;
        
        public ContactoRepository(PersonasContext context)
        {
            Db = context;
            DbSet = Db.Set<Contacto>();
        }

        public void Crear(Contacto modelo)
        {
            DbSet.Add(modelo);
        }

        public void Modificar(Contacto modelo)
        {
            DbSet.Update(modelo);
        }

        public void Eliminar(Contacto modelo)
        {
            DbSet.Remove(modelo);
        }

        public async Task<Contacto> BuscaPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Contacto>> BuscaPorIdPersona(Guid idPersona)
        {
            return await DbSet.AsNoTracking().Where(c => c.IdPersona == idPersona).ToListAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Contacto> BuscaPorIdPersona_TipoContacto(Guid idPersona, string tipoContacto)
        {
            return await DbSet.AsNoTracking().Where(c => c.IdPersona == idPersona & c.TipoContacto == tipoContacto).FirstOrDefaultAsync();
        }
    }
}
