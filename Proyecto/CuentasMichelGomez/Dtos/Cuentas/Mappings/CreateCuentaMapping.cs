using AutoMapper;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Cuentas.Mappings
{
    public class CreateCuentaMapping : Profile
    {
        public CreateCuentaMapping()
        {
            CreateMap<CreateCuenta, Cuenta>();
        }
    }
}
