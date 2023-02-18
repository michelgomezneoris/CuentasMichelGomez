using AutoMapper;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Personas.Mappings
{
    public class UpdatePersonaMapping : Profile
    {
        public UpdatePersonaMapping()
        {
            CreateMap<UpdatePersona, Persona>();
        }
    }
}
