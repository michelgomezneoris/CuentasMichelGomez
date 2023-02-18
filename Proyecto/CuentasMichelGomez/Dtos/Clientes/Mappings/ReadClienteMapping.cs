using AutoMapper;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Dtos.Clientes.Mappings
{
    public class ReadClienteMapping : Profile
    {
        public ReadClienteMapping()
        {
            CreateMap<Cliente, ReadCliente>();
        }
    }
}