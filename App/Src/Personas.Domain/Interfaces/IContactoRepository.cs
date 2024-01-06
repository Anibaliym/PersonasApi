using Personas.Domain.Core.Data;
using Personas.Domain.Entities;

namespace Personas.Domain.Interfaces
{
    public interface IContactoRepository : IRepository<Contacto>
    {
        void Crear(Contacto modelo);
        void Modificar(Contacto modelo);
        void Eliminar(Contacto modelo);

        Task<Contacto> BuscaPorId(Guid id);
        Task<Contacto> BuscaPorIdPersona_TipoContacto(Guid id, string tipoContacto);
        Task<IList<Contacto>> BuscaPorIdPersona(Guid idPersona);
    }
}
