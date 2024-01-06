using Personas.Application.EventSourcedNormalizers.Contacto;
using Personas.Application.ViewModels.Contacto;
using Personas.Domain.Core.Messaging;

namespace Personas.Application.Interfaces
{
    public interface IContactoAppService : IDisposable
    {
        Task<CommandResponse> Crear(ContactoCrearViewModel modelo);
        Task<CommandResponse> Modificar(ContactoModificarViewModel modelo);
        Task<CommandResponse> Eliminar(Guid id);
        Task<ContactoViewModel> BuscaPorId(Guid id);
        Task<ContactoViewModel> BuscaPorIdPersona_TipoContacto(Guid id, string tipoContacto);
        Task<IList<ContactoViewModel>> BuscaPorIdPersona(Guid idPersona);

        Task<IList<ContactoHistoryData>> GetAllHistory(Guid id);
    }
}
