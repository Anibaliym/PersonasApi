using Personas.Application.EventSourcedNormalizers.Direccion;
using Personas.Application.ViewModels.Direccion;
using Personas.Domain.Core.Messaging;

namespace Personas.Application.Interfaces
{
    public interface IDireccionAppService : IDisposable
    {
        Task<CommandResponse> Crear(DireccionCrearViewModel modelo);
        Task<CommandResponse> Modificar(DireccionModificarViewModel modelo);
        Task<CommandResponse> Eliminar(Guid id);
        Task<DireccionViewModel> BuscaPorId(Guid id);
        Task<DireccionViewModel> BuscaPorIdPersona(Guid idPersona);

        Task<IList<DireccionHistoryData>> GetAllHistory(Guid id);
    }
}
