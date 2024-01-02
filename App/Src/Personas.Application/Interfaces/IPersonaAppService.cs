using Personas.Application.EventSourcedNormalizers.Persona;
using Personas.Application.ViewModels.Persona;
using Personas.Domain.Core.Messaging;

namespace Personas.Application.Interfaces
{
    public interface IPersonaAppService : IDisposable
    {
        Task<CommandResponse> Crear(PersonaCrearViewModel modelo);
        Task<CommandResponse> Modificar(PersonaModificarViewModel modelo);
        Task<CommandResponse> Eliminar(Guid id);
        Task<PersonaViewModel> BuscaPorId(Guid id);
        Task<PersonaViewModel> BuscaPorRut(string rut);
        Task<IList<PersonaViewModel>> BuscaPorNombreCoincidencias(string nombre);
        Task<IList<PersonaViewModel>> BuscaPorApellidoPaternoCoincidencias(string apellidoPaterno);
        Task<IList<PersonaViewModel>> BuscaPorApellidoMaternoCoincidencias(string apellidoMaterno);

        Task<IList<PersonaHistoryData>> GetAllHistory(Guid id);
    }
}
