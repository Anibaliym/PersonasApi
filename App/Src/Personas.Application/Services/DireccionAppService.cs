using AutoMapper;
using Personas.Application.EventSourcedNormalizers.Direccion;
using Personas.Application.Interfaces;
using Personas.Application.ViewModels.Direccion;
using Personas.Domain.Commands.Direccion.Commands;
using Personas.Domain.Core.Mediator;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Interfaces;
using Personas.Infra.Data.PostgreSQL.Repository.EventSourcing;

namespace Personas.Application.Services
{
    public class DireccionAppService : IDireccionAppService
    {
        private readonly IMapper _mapper;
        private readonly IDireccionRepository _direccionRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public DireccionAppService(IMapper mapper, IDireccionRepository direccionRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _direccionRepository = direccionRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<DireccionViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<DireccionViewModel>(await _direccionRepository.BuscaPorId(id));
        }

        public async Task<DireccionViewModel> BuscaPorIdPersona(Guid idPersona)
        {
            return _mapper.Map<DireccionViewModel>(await _direccionRepository.BuscaPorIdPersona(idPersona));
        }

        public async Task<CommandResponse> Crear(DireccionCrearViewModel modelo)
        {
            var createCommand = _mapper.Map<DireccionCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public async Task<CommandResponse> Eliminar(Guid id)
        {
            var deleteCommand = new DireccionEliminarCommand(id);
            return await _mediator.SendCommand(deleteCommand);
        }

        public async Task<CommandResponse> Modificar(DireccionModificarViewModel modelo)
        {
            var updateCommand = _mapper.Map<DireccionModificarCommand>(modelo);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<IList<DireccionHistoryData>> GetAllHistory(Guid id)
        {
            return DireccionHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
