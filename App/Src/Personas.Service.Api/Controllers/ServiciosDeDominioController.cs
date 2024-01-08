using Microsoft.AspNetCore.Mvc;
using Personas.Application.Interfaces;
using Personas.Application.ViewModels.ServiciosDeDominio;

namespace Personas.Service.Api.Controllers
{
    [Route("api/[controller]")]
    public class ServiciosDeDominioController : ApiController
    {
        private readonly IServiciosDominiosAppService _ServiciosDominiosAppService;

        public ServiciosDeDominioController(IServiciosDominiosAppService serviciosDominiosAppService)
        {
            _ServiciosDominiosAppService = serviciosDominiosAppService;
        }

        [HttpGet("BuscaTodaInformacionPersonal_Persona/{idPersona:Guid}")]
        public async Task<Obtener_PersonaDireccionContactoViewModel> BuscaTodaInformacionPersonal_Persona(Guid idPersona)
        {
            return await _ServiciosDominiosAppService.BuscaTodaInformacionPersonal_Persona(idPersona);
        }

        [HttpPost("CrearPersonaCon_DireccionYContacto")]
        public async Task<IActionResult> CrearPersonaCon_DireccionYContacto(Crear_PersonaContactoDireccionViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _ServiciosDominiosAppService.CrearPersonaCon_DireccionYContacto(modelo));
        }

        [HttpDelete("EliminarContactoPersona/{idPersona:Guid}")]
        public async Task<IActionResult> EliminarContactoPersona(Guid idPersona)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _ServiciosDominiosAppService.EliminarPersonaDireccionContacto(idPersona));
        }
    }
}
