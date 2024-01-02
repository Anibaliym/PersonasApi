using Personas.Domain.Core.Data;
using Personas.Domain.Entities;

namespace Personas.Domain.Interfaces
{
    public interface IPersonaRepository : IRepository<Persona>
    {
        void Crear(Persona modelo);
        void Modificar(Persona modelo);
        void Eliminar(Persona modelo);

        Task<Persona> BuscaPorId(Guid id);
        Task<Persona> BuscaPorRut(string rut);
        Task<IEnumerable<Persona>> BuscaPorNombreCoincidencias(string nombre);
        Task<IEnumerable<Persona>> BuscaPorApellidoPaternoCoincidencias(string apellidoPaterno);
        Task<IEnumerable<Entities.Persona>> BuscaPorApellidoMaternoCoincidencias(string apellidoMaterno);
    }
}
