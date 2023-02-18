using AutoMapper;
using CuentasMichelGomez.Dtos.Movimientos.Resolvers;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Movimientos.Mappings
{
    public class CreateMovimientoMapping : Profile
    {
        public CreateMovimientoMapping()
        {
            CreateMap<CreateMovimiento, Movimiento>()
                .ForMember(dto => dto.Saldo, opt => opt.MapFrom<CreateMovimientoSaldoResolver>());
        }
    }
}
