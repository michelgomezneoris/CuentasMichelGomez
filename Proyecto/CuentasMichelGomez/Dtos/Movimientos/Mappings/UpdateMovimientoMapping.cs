using AutoMapper;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Movimientos.Mappings
{
    public class UpdateMovimientoMapping : Profile
    {
        public UpdateMovimientoMapping()
        {
            CreateMap<UpdateMovimiento, Movimiento>();
        }
    }
}
