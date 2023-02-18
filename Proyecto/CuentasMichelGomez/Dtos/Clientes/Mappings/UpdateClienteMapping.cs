using AutoMapper;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Clientes.Mappings
{
    public class UpdateClienteMapping : Profile
    {
        public UpdateClienteMapping()
        {
            CreateMap<UpdateCliente, Cliente>();
        }
    }
}
