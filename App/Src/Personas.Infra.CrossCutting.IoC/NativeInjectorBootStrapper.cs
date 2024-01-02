using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Personas.Application.Interfaces;
using Personas.Application.Services;
using Personas.Domain.Commands.Persona.Commands;
using Personas.Domain.Commands.Persona.Handlers;
using Personas.Domain.Core.Events;
using Personas.Domain.Core.Mediator;
using Personas.Domain.Core.Messaging;
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

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Events
            services.AddScoped<INotificationHandler<PersonaCrearEvent>, PersonaCrearEventHandler>();
            services.AddScoped<INotificationHandler<PersonaModificarEvent>, PersonaModificarEventHandler>();
            services.AddScoped<INotificationHandler<PersonaEliminarEvent>, PersonaEliminarEventHandler>();


            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Commands
            services.AddScoped<IRequestHandler<PersonaCrearCommand, CommandResponse>, PersonaCommandHandler>();
            services.AddScoped<IRequestHandler<PersonaModificarCommand, CommandResponse>, PersonaCommandHandler>();
            services.AddScoped<IRequestHandler<PersonaEliminarCommand, CommandResponse>, PersonaCommandHandler>();


            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //InfraData
            services.AddScoped<IPersonaRepository, PersonaRepository>();

            services.AddScoped<PersonasContext>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Infra Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}
