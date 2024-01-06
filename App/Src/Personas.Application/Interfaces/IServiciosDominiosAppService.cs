using Personas.Application.ViewModels.ServiciosDeDominio;
using Personas.Domain.Core.Messaging;

namespace Personas.Application.Interfaces
{
    public interface IServiciosDominiosAppService : IDisposable
    {
        Task<CommandResponse> CrearPersonaDireccionContacto(Crear_PersonaDireccionContactoViewModel modelo);

        Task<CommandResponse> EliminarPersonaDireccionContacto(Guid idPersona);

        Task<Obtener_PersonaDireccionContactoViewModel> BuscaTodaInformacionPersonal_Persona(Guid idPersona);
    }
}
