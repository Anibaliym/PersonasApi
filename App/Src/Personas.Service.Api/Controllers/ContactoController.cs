using Microsoft.AspNetCore.Mvc;
using Personas.Application.EventSourcedNormalizers.Contacto;
using Personas.Application.Interfaces;
using Personas.Application.ViewModels.Contacto;

namespace Personas.Service.Api.Controllers
{
    [Route("api/[controller]")]
    public class ContactoController : ApiController
    {
        private readonly IContactoAppService _contactoAppService;

        public ContactoController(IContactoAppService contactoAppService)
        {
            _contactoAppService = contactoAppService;
        }

        [HttpPut("Modificar")]
        public async Task<IActionResult> Modificar(ContactoModificarViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _contactoAppService.Modificar(modelo));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear(ContactoCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _contactoAppService.Crear(modelo));
        }

        [HttpDelete("Eliminar/{id:Guid}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            return CustomResponse(await _contactoAppService.Eliminar(id));
        }

        [HttpGet("BuscaPorId/{id:guid}")]
        public async Task<ContactoViewModel> BuscaPorId(Guid id)
        {
            return await _contactoAppService.BuscaPorId(id);
        }

        [HttpGet("BuscaPorIdPersona/{idPersona:guid}")]
        public async Task<IList<ContactoViewModel>> BuscaPorIdPersona(Guid idPersona)
        {
            return await _contactoAppService.BuscaPorIdPersona(idPersona);
        }

        [HttpGet("BuscaPorIdPersona_TipoContacto/{id:guid}")]
        public async Task<ContactoViewModel> BuscaPorIdPersona_TipoContacto(Guid id, string tipoContacto)
        {
            return await _contactoAppService.BuscaPorIdPersona_TipoContacto(id, tipoContacto);
        }

        [HttpGet("History/{id:guid}")]
        public async Task<IList<ContactoHistoryData>> History(Guid id)
        {
            return await _contactoAppService.GetAllHistory(id);
        }
    }
}
