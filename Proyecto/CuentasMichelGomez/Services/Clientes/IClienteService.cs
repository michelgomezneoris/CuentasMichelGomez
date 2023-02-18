using CuentasMichelGomez.Dtos.Clientes;

namespace CuentasMichelGomez.Services.Clientes
{
    public interface IClienteService
    {
        Task<ReadCliente> Create(CreateCliente createRequest);
        Task<ReadCliente> Read(long id);
        Task<ReadCliente> Update(UpdateCliente updateRequest);
        Task Delete(long id);
        Task<ICollection<ReadCliente>> GetAll();

    }
}
