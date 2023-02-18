using AutoMapper;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Cuentas.Mappings
{
    public class UpdateCuentaMapping : Profile
    {
        public UpdateCuentaMapping()
        {
            CreateMap<UpdateCuenta, Cuenta>();
        }
    }
}
