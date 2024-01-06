using Microsoft.AspNetCore.Mvc;
using Personas.Application.EventSourcedNormalizers.Persona;
using Personas.Application.Interfaces;
using Personas.Application.ViewModels.Persona;

namespace Personas.Service.Api.Controllers
{
    [Route("api/[controller]")]
    public class PersonaController : ApiController
    {
        private readonly IPersonaAppService _personaAppService;
        public PersonaController(IPersonaAppService personaAppService)
        {
            _personaAppService = personaAppService;
        }

        [HttpGet("BuscaPorId/{id:guid}")]
        public async Task<PersonaViewModel> BuscaPorId(Guid id)
        {
            return await _personaAppService.BuscaPorId(id);
        }


        [HttpGet("BuscaPorRut")]
        public async Task<PersonaViewModel> BuscaPorRut(string rut)
        {
            return await _personaAppService.BuscaPorRut(rut);
        }

        [HttpGet("BuscaPorNombreCoincidencias")]
        public async Task<IList<PersonaViewModel>> BuscaPorNombreCoincidencias(string nombre)
        {
            return await _personaAppService.BuscaPorNombreCoincidencias(nombre);
        }

        [HttpGet("BuscaPorApellidoPaternoCoincidencias")]
        public async Task<IList<PersonaViewModel>> BuscaPorApellidoPaternoCoincidencias(string apellidoPaterno)
        {
            return await _personaAppService.BuscaPorApellidoPaternoCoincidencias(apellidoPaterno);
        }

        [HttpGet("BuscaPorApellidoMaternoCoincidencias")]
        public async Task<IList<PersonaViewModel>> BuscaPorApellidoMaternoCoincidencias(string apellidoMaterno)
        {
            return await _personaAppService.BuscaPorApellidoMaternoCoincidencias(apellidoMaterno);
        }

        [HttpPut("Modificar")]
        public async Task<IActionResult> Modificar(PersonaModificarViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _personaAppService.Modificar(modelo));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear(PersonaCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _personaAppService.Crear(modelo));
        }

        [HttpDelete("Eliminar/{id:Guid}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            return CustomResponse(await _personaAppService.Eliminar(id));
        }

        [HttpGet("History/{id:guid}")]
        public async Task<IList<PersonaHistoryData>> History(Guid id)
        {
            return await _personaAppService.GetAllHistory(id);
        }
    }
}
