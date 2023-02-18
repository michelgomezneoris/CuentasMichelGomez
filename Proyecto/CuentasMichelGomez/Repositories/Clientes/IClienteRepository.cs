using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Repositories.Clientes
{
    public interface IClienteRepository
    {
        Task<Cliente> Create(Cliente entity);
        Task<Cliente> Read(long id);
        Task<Cliente> ReadByIdentificacion(string identificacion);
        Task<Cliente> Update(Cliente entity);
        Task Delete(long id);
        Task<List<Cliente>> GetAll();

    }
}
