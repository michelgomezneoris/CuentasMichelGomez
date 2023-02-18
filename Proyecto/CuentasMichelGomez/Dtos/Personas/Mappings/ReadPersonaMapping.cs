using AutoMapper;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Personas.Mappings
{
    public class ReadPersonaMapping : Profile
    {
        public ReadPersonaMapping()
        {
            CreateMap<Persona, ReadPersona>();
        }
    }
}