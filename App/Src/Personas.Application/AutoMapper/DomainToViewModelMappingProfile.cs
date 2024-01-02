using AutoMapper;
using Personas.Application.ViewModels.Direccion;
using Personas.Application.ViewModels.Persona;
using Personas.Domain.Entities;

namespace Personas.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Persona, PersonaViewModel>();
            CreateMap<Direccion, DireccionViewModel>();
            //CreateMap<Contacto, ContactoViewModel>();
        }
    }
}
