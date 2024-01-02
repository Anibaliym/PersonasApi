using Microsoft.EntityFrameworkCore;
using Personas.Domain.Core.Data;
using Personas.Domain.Entities;
using Personas.Domain.Interfaces;
using Personas.Infra.Data.PostgreSQL.Context;

namespace Personas.Infra.Data.PostgreSQL.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        protected readonly PersonasContext Db;
        protected readonly DbSet<Persona> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public PersonaRepository(PersonasContext context)
        {
            Db = context;
            DbSet = Db.Set<Persona>();
        }

        public async Task<IEnumerable<Persona>> BuscaPorApellidoMaternoCoincidencias(string apellidoMaterno)
        {
            return DbSet.Where(p => EF.Functions.Like(p.ApellidoMaterno.ToUpper(), "%" + apellidoMaterno.ToUpper() + "%")).ToList();
        }

        public async Task<IEnumerable<Persona>> BuscaPorApellidoPaternoCoincidencias(string apellidoPaterno)
        {
            return DbSet.Where(p => EF.Functions.Like(p.ApellidoPaterno.ToUpper(), "%" + apellidoPaterno.ToUpper() + "%")).ToList();
        }

        public async Task<Persona> BuscaPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Persona>> BuscaPorNombreCoincidencias(string nombre)
        {
            return DbSet.Where(p => EF.Functions.Like(p.Nombre.ToUpper(), "%" + nombre.ToUpper() + "%")).ToList();
        }

        public async Task<Persona> BuscaPorRut(string rut)
        {
            return await DbSet.AsNoTracking().Where(P => P.Rut == rut).FirstOrDefaultAsync();
        }

        public void Crear(Persona modelo)
        {
            DbSet.Add(modelo);
        }

        public void Eliminar(Persona modelo)
        {
            DbSet.Remove(modelo);
        }

        public void Modificar(Persona modelo)
        {
            DbSet.Update(modelo);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
