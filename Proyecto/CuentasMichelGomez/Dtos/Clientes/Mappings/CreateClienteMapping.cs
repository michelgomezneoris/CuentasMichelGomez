using AutoMapper;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Clientes.Mappings
{
    public class CreateClienteMapping : Profile
    {
        public CreateClienteMapping()
        {
            CreateMap<CreateCliente, Cliente>();
        }
    }
}
