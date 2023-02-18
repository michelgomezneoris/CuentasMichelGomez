using AutoMapper;
using CuentasMichelGomez.Dtos.Movimientos.Resolvers;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Reportes.Mappings
{
    public class ReadReporteMapping : Profile
    {
        public ReadReporteMapping()
        {
            CreateMap<Movimiento, ReadReporte>()
                .ForMember(dto => dto.MovimientoId, opt => opt.MapFrom<ReadMovimientoReporteResolver>());
        }
    }
}