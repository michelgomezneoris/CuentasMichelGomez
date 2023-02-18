using AutoMapper;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Movimientos.Mappings
{
    public class ReadMovimientoMapping : Profile
    {
        public ReadMovimientoMapping()
        {
            CreateMap<Movimiento, ReadMovimiento>();
        }
    }
}