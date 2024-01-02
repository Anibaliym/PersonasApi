using AutoMapper;
using Personas.Application.ViewModels.Direccion;
using Personas.Application.ViewModels.Persona;
using Personas.Domain.Commands.Direccion.Commands;
using Personas.Domain.Commands.Persona.Commands;

namespace Personas.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Persona
            CreateMap<PersonaCrearViewModel, PersonaCrearCommand>().ConstructUsing(persona => new PersonaCrearCommand(
                persona.Rut,
                persona.Nombre,
                persona.ApellidoPaterno,
                persona.ApellidoMaterno,
                persona.FechaNacimiento,
                persona.Genero
            ));

            CreateMap<PersonaModificarViewModel, PersonaModificarCommand>().ConstructUsing(persona => new PersonaModificarCommand(
                persona.Id,
                persona.Nombre,
                persona.ApellidoPaterno,
                persona.ApellidoMaterno,
                persona.FechaNacimiento,
                persona.Genero
            ));
            #endregion

            #region Direccion
            CreateMap<DireccionCrearViewModel, DireccionCrearCommand>().ConstructUsing(direccion => new DireccionCrearCommand(
                direccion.IdPersona, 
                direccion.Calle, 
                direccion.Numero, 
                direccion.NumeroCasaDepartamento, 
                direccion.Comuna
            ));

            CreateMap<DireccionModificarViewModel, DireccionModificarCommand>().ConstructUsing(direccion => new DireccionModificarCommand(
                direccion.Id,
                direccion.Calle,
                direccion.Numero,
                direccion.NumeroCasaDepartamento,
                direccion.Comuna
            ));
            #endregion

            #region Contacto
            #endregion
        }
    }
}
