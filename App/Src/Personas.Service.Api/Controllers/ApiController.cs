using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Core.Models;

namespace Personas.Service.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsOperationValid())
            {
                return Ok(JsonConvert.SerializeObject(result));
            }

            return BadRequest(JsonConvert.SerializeObject(result));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var rc = new ResponseCommand();
            rc.Data = string.Empty;

            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            rc.Result = _errors.Count < 1;
            rc.Errors = _errors;

            return CustomResponse(JsonConvert.SerializeObject(rc));
        }

        protected ActionResult CustomResponse(CommandResponse commandResponse)
        {
            if (!commandResponse.Result)
            {
                AddError("No se pudo ejecutar correctamente el servicio invocado");
                foreach (var error in commandResponse.ValidationResult.Errors)
                {
                    AddError(error.ErrorMessage);
                }
            }

            var rc = new ResponseCommand();
            rc.Result = commandResponse.Result;
            rc.Data = commandResponse.Data;
            rc.Errors = _errors;

            return CustomResponse(rc);
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}
