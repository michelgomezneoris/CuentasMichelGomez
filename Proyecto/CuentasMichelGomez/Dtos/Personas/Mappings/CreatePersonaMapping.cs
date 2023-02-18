using AutoMapper;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Personas.Mappings
{
    public class CreatePersonaMapping : Profile
    {
        public CreatePersonaMapping()
        {
            CreateMap<CreatePersona, Persona>();
        }
    }
}
