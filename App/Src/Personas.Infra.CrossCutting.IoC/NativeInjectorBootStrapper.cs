using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Personas.Application.Interfaces;
using Personas.Application.Services;
using Personas.Domain.Commands.Contacto.Commands;
using Personas.Domain.Commands.Contacto.Handlers;
using Personas.Domain.Commands.Direccion.Commands;
using Personas.Domain.Commands.Direccion.Handlers;
using Personas.Domain.Commands.Persona.Commands;
using Personas.Domain.Commands.Persona.Handlers;
using Personas.Domain.Core.Events;
using Personas.Domain.Core.Mediator;
using Personas.Domain.Core.Messaging;
using Personas.Domain.Events.Contacto.Events;
using Personas.Domain.Events.Contacto.Handlers;
using Personas.Domain.Events.Direccion.Events;
using Personas.Domain.Events.Direccion.Handlers;
using Personas.Domain.Events.Persona.Events;
using Personas.Domain.Events.Persona.Handlers;
using Personas.Domain.Interfaces;
using Personas.Infra.CrossCutting.Bus;
using Personas.Infra.Data.PostgreSQL.Context;
using Personas.Infra.Data.PostgreSQL.EventSourcing;
using Personas.Infra.Data.PostgreSQL.Repository;
using Personas.Infra.Data.PostgreSQL.Repository.EventSourcing;

namespace Personas.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Application
            services.AddScoped<IPersonaAppService, PersonaAppService>();
            services.AddScoped<IDireccionAppService, DireccionAppService>();
            services.AddScoped<IContactoAppService, ContactoAppService>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Events

            //Persona
            services.AddScoped<INotificationHandler<PersonaCrearEvent>, PersonaCrearEventHandler>();
            services.AddScoped<INotificationHandler<PersonaModificarEvent>, PersonaModificarEventHandler>();
            services.AddScoped<INotificationHandler<PersonaEliminarEvent>, PersonaEliminarEventHandler>();

            //Dirección
            services.AddScoped<INotificationHandler<DireccionCrearEvent>, DireccionCrearEventHandler>();
            services.AddScoped<INotificationHandler<DireccionModificarEvent>, DireccionModificarEventHandler>();
            services.AddScoped<INotificationHandler<DireccionEliminarEvent>, DireccionEliminarEventHandler>();

            //Contacto
            services.AddScoped<INotificationHandler<ContactoCrearEvent>, ContactoCrearEventHandler>();
            services.AddScoped<INotificationHandler<ContactoModificarEvent>, ContactoModificarEventHandler>();
            services.AddScoped<INotificationHandler<ContactoEliminarEvent>, ContactoEliminarEventHandler>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Commands

            //Persona
            services.AddScoped<IRequestHandler<PersonaCrearCommand, CommandResponse>, PersonaCommandHandler>();
            services.AddScoped<IRequestHandler<PersonaModificarCommand, CommandResponse>, PersonaCommandHandler>();
            services.AddScoped<IRequestHandler<PersonaEliminarCommand, CommandResponse>, PersonaCommandHandler>();

            //Dirección
            services.AddScoped<IRequestHandler<DireccionCrearCommand, CommandResponse>, DireccionCommandHandler>();
            services.AddScoped<IRequestHandler<DireccionModificarCommand, CommandResponse>, DireccionCommandHandler>();
            services.AddScoped<IRequestHandler<DireccionEliminarCommand, CommandResponse>, DireccionCommandHandler>();

            //Contacto
            services.AddScoped<IRequestHandler<ContactoCrearCommand, CommandResponse>, ContactoCommandHandler>();
            services.AddScoped<IRequestHandler<ContactoModificarCommand, CommandResponse>, ContactoCommandHandler>();
            services.AddScoped<IRequestHandler<ContactoEliminarCommand, CommandResponse>, ContactoCommandHandler>();


            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //InfraData
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IDireccionRepository, DireccionRepository>();
            services.AddScoped<IContactoRepository, ContactoRepository>();

            services.AddScoped<PersonasContext>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Infra Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}
