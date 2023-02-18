using AutoMapper;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Cuentas.Mappings
{
    public class ReadCuentaMapping : Profile
    {
        public ReadCuentaMapping()
        {
            CreateMap<Cuenta, ReadCuenta>();
        }
    }
}