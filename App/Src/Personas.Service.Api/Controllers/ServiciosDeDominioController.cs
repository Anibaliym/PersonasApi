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

        [HttpPost("CrearPersonaDireccionContacto")]
        public async Task<IActionResult> CrearTransitoConDetalle(Crear_PersonaDireccionContactoViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _ServiciosDominiosAppService.CrearPersonaDireccionContacto(modelo));
        }

        [HttpDelete("EliminarContactoPersona/{idPersona:Guid}")]
        public async Task<IActionResult> EliminarContactoPersona(Guid idPersona)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _ServiciosDominiosAppService.EliminarPersonaDireccionContacto(idPersona));
        }
    }
}
