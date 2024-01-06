using AutoMapper;
using Personas.Application.Interfaces;
using Personas.Application.ViewModels.Contacto;
using Personas.Application.ViewModels.Direccion;
using Personas.Application.ViewModels.ServiciosDeDominio;
using Personas.Domain.Commands.Contacto.Commands;
using Personas.Domain.Commands.Direccion.Commands;
using Personas.Domain.Commands.Persona.Commands;
using Personas.Domain.Core.Mediator;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Interfaces;

namespace Personas.Application.Services
{
    public class ServiciosDeDominioAppService : IServiciosDominiosAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        private readonly IPersonaRepository _personaRepository;
        private readonly IDireccionRepository _direccionRepository;
        private readonly IContactoRepository _contactoRepository;

        public ServiciosDeDominioAppService(IMapper mapper, IMediatorHandler mediator, IPersonaRepository personaRepository, IDireccionRepository direccionRepository, IContactoRepository contactoRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _personaRepository = personaRepository;
            _direccionRepository = direccionRepository;
            _contactoRepository = contactoRepository;
        }

        public async Task<Obtener_PersonaDireccionContactoViewModel> BuscaTodaInformacionPersonal_Persona(Guid idPersona)
        {
            Obtener_PersonaDireccionContactoViewModel response = new Obtener_PersonaDireccionContactoViewModel();

            response.Persona = await _personaRepository.BuscaPorId(idPersona);

            if (response.Persona == null) return null; 

            response.Direccion = await _direccionRepository.BuscaPorIdPersona(idPersona);
            response.Contacto = await _contactoRepository.BuscaPorIdPersona(idPersona);

            return response; 
        }

        public async Task<CommandResponse> CrearPersonaDireccionContacto(Crear_PersonaDireccionContactoViewModel modelo)
        {
            Guid idPersona_creada = Guid.NewGuid();

            CommandResponse response = new();
            CommandResponse responseCrearPersona = new CommandResponse();
            CommandResponse responseCrearDireccion = new CommandResponse();
            CommandResponse responseCrearContacto = new CommandResponse();
            CommandResponse responseEliminarPersona = new CommandResponse();
            CommandResponse responseEliminarDireccion = new CommandResponse();

            ContactoCrearViewModel contactoCrear = new ContactoCrearViewModel();
            DireccionCrearViewModel direccionCrear = new DireccionCrearViewModel();

            #region Crea registro "Persona"
            var personaRegisterCommand = _mapper.Map<PersonaCrearCommand>(modelo.Persona);
            responseCrearPersona = await _mediator.SendCommand(personaRegisterCommand);

            if (responseCrearPersona.Result == false)
            {
                foreach (var item in responseCrearPersona.ValidationResult.Errors)
                    response.ValidationResult.Errors.Add(item);

                return response; 
            }

            //Obtiene el id de la persona creada recientemente.
            idPersona_creada = Guid.Parse(responseCrearPersona?.Data?.GetType()?.GetProperty("Id")?.GetValue(responseCrearPersona?.Data)?.ToString());

            #endregion

            #region Crea registro "Direccion"

            direccionCrear.IdPersona = idPersona_creada;
            direccionCrear.Calle = modelo.Direccion.Calle;
            direccionCrear.Numero = modelo.Direccion.Numero;
            direccionCrear.NumeroCasaDepartamento = modelo.Direccion.NumeroCasaDepartamento;
            direccionCrear.Comuna = modelo.Direccion.Comuna;

            var direccionRegisterCommand = _mapper.Map<DireccionCrearCommand>(direccionCrear);
            responseCrearDireccion = await _mediator.SendCommand(direccionRegisterCommand);

            if (responseCrearDireccion.Result == false)
            {
                foreach (var item in responseCrearDireccion.ValidationResult.Errors)
                    response.ValidationResult.Errors.Add(item);

                //se elimina el registro persona, creado previamente
                var personaRemoveCommand = _mapper.Map<PersonaEliminarCommand>(idPersona_creada);
                responseEliminarPersona = await _mediator.SendCommand(personaRemoveCommand);

                return response;
            }

            #endregion

            #region Crea registro "Contacto"
            contactoCrear.IdPersona = idPersona_creada;
            contactoCrear.Celular = modelo.Contacto.Celular;
            contactoCrear.Email = modelo.Contacto.Email;
            contactoCrear.TipoContacto = modelo.Contacto.TipoContacto;

            var contactoRegisterCommand = _mapper.Map<ContactoCrearCommand>(contactoCrear);
            responseCrearContacto = await _mediator.SendCommand(contactoRegisterCommand);

            if (responseCrearContacto.Result == false)
            {
                foreach (var item in responseCrearContacto.ValidationResult.Errors)
                    response.ValidationResult.Errors.Add(item);

                //se elimina el registro persona, creado previamente
                var personaRemoveCommand = _mapper.Map<PersonaEliminarCommand>(idPersona_creada);
                responseEliminarPersona = await _mediator.SendCommand(personaRemoveCommand);

                //se elimina el registro dirección, creado previamente
                var direccionRemoveCommand = _mapper.Map<DireccionEliminarCommand>(idPersona_creada);
                responseEliminarDireccion = await _mediator.SendCommand(direccionRemoveCommand);

                return response;
            }

            #endregion

            if (responseCrearPersona.Result & responseCrearDireccion.Result & responseCrearContacto.Result) {
                response.Result = true;

                response.Data = new { 
                    Persona = responseCrearPersona.Data,
                    Direccion = responseCrearDireccion.Data,
                    Contacto = responseCrearContacto.Data,
                }; 
            }

            return response; 
        }

        public async Task<CommandResponse> EliminarPersonaDireccionContacto(Guid idPersona)
        {
            CommandResponse response = new();
            FluentValidation.Results.ValidationFailure item = new FluentValidation.Results.ValidationFailure();
            
            Guid idDireccion = Guid.NewGuid();
            Guid idContacto = Guid.NewGuid();

            CommandResponse responseEliminarPersona = new CommandResponse();
            CommandResponse responseEliminarDireccion = new CommandResponse();
            CommandResponse responseEliminarContacto = new CommandResponse();

            var persona = await _personaRepository.BuscaPorId(idPersona); 
            var direccion = await _direccionRepository.BuscaPorIdPersona(idPersona);
            var contactos = await _contactoRepository.BuscaPorIdPersona(idPersona);


            //se elimina el registro persona en el caso que exista, creado previamente
            if (persona != null)
            {
                idDireccion = Guid.Parse(direccion?.GetType()?.GetProperty("Id")?.GetValue(direccion)?.ToString());

                var personaRemoveCommand = _mapper.Map<PersonaEliminarCommand>(idPersona);
                responseEliminarPersona = await _mediator.SendCommand(personaRemoveCommand);
            }
            else
            {
                item.ErrorMessage = $"La persona con el id { idPersona }, no existe. operación cancelada";

                response.Result = false;
                response.ValidationResult.Errors.Add(item);

                return response;
            }

            //se elimina el registro dirección en el caso que exista, creado previamente
            if (direccion != null) { 
                var direccionRemoveCommand = _mapper.Map<DireccionEliminarCommand>(idDireccion);
                responseEliminarDireccion = await _mediator.SendCommand(direccionRemoveCommand);
            }

            if (contactos.Count > 0) { 
                foreach (var contacto in contactos) {
                    //se eliminan los registros de contactos en el caso que existan.
                    var contactoRemoveCommand = _mapper.Map<ContactoEliminarCommand>(contacto.Id);
                    responseEliminarContacto = await _mediator.SendCommand(contactoRemoveCommand);
                }
            }

            response.Result = true;

            return response;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
