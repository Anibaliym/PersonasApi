using Personas.Application.ViewModels.ServiciosDeDominio;
using Personas.Domain.Core.Messaging;

namespace Personas.Application.Interfaces
{
    public interface IServiciosDominiosAppService : IDisposable
    {
        Task<CommandResponse> CrearPersonaCon_DireccionYContacto(Crear_PersonaContactoDireccionViewModel modelo);
        Task<Obtener_PersonaDireccionContactoViewModel> BuscaTodaInformacionPersonal_Persona(Guid idPersona);
        Task<CommandResponse> EliminarPersonaDireccionContacto(Guid idPersona);
    }
}
