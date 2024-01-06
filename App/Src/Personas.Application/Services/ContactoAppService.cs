using AutoMapper;
using Personas.Application.EventSourcedNormalizers.Contacto;
using Personas.Application.Interfaces;
using Personas.Application.ViewModels.Contacto;
using Personas.Domain.Commands.Contacto.Commands;
using Personas.Domain.Core.Mediator;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Interfaces;
using Personas.Infra.Data.PostgreSQL.Repository.EventSourcing;

namespace Personas.Application.Services
{
    public class ContactoAppService : IContactoAppService
    {
        private readonly IMapper _mapper;
        private readonly IContactoRepository _contactoRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public ContactoAppService(IMapper mapper, IContactoRepository contactoRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _contactoRepository = contactoRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<ContactoViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<ContactoViewModel>(await _contactoRepository.BuscaPorId(id));
        }

        public async Task<IList<ContactoViewModel>> BuscaPorIdPersona(Guid idPersona)
        {
            return _mapper.Map<IList<ContactoViewModel>>(await _contactoRepository.BuscaPorId(idPersona)).ToList();
        }

        public async Task<ContactoViewModel> BuscaPorIdPersona_TipoContacto(Guid id, string tipoContacto)
        {
            return _mapper.Map<ContactoViewModel>(await _contactoRepository.BuscaPorIdPersona_TipoContacto(id, tipoContacto));
        }

        public async Task<CommandResponse> Crear(ContactoCrearViewModel modelo)
        {
            var createCommand = _mapper.Map<ContactoCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public async Task<CommandResponse> Eliminar(Guid id)
        {
            var deleteCommand = new ContactoEliminarCommand(id);
            return await _mediator.SendCommand(deleteCommand);
        }

        public async Task<CommandResponse> Modificar(ContactoModificarViewModel modelo)
        {
            var updateCommand = _mapper.Map<ContactoModificarCommand>(modelo);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<IList<ContactoHistoryData>> GetAllHistory(Guid id)
        {
            return ContactoHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
