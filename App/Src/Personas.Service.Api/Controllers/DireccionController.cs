using Microsoft.AspNetCore.Mvc;
using Personas.Application.EventSourcedNormalizers.Direccion;
using Personas.Application.Interfaces;
using Personas.Application.ViewModels.Direccion;

namespace Personas.Service.Api.Controllers
{
    [Route("api/[controller]")]
    public class DireccionController : ApiController
    {
        private readonly IDireccionAppService _direccionAppService;

        public DireccionController(IDireccionAppService direccionAppService)
        {
            _direccionAppService = direccionAppService;
        }

        [HttpGet("BuscaPorId/{id:guid}")]
        public async Task<DireccionViewModel> BuscaPorId(Guid id)
        {
            return await _direccionAppService.BuscaPorId(id);
        }

        [HttpGet("BuscaPorIdPersona/{idPersona:guid}")]
        public async Task<DireccionViewModel> BuscaPorIdPersona(Guid idPersona)
        {
            return await _direccionAppService.BuscaPorIdPersona(idPersona);
        }

        [HttpPut("Modificar")]
        public async Task<IActionResult> Modificar(DireccionModificarViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _direccionAppService.Modificar(modelo));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear(DireccionCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _direccionAppService.Crear(modelo));
        }

        [HttpDelete("Eliminar/{id:Guid}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            return CustomResponse(await _direccionAppService.Eliminar(id));
        }

        [HttpGet("History/{id:guid}")]
        public async Task<IList<DireccionHistoryData>> History(Guid id)
        {
            return await _direccionAppService.GetAllHistory(id);
        }
    }
}
