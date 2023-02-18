using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Repositories.Cuentas
{
    public interface ICuentaRepository
    {
        Task<Cuenta> Create(Cuenta entity);
        Task<Cuenta> Read(long id);
        Cuenta ReadSync(long id);
        Task<Cuenta> Update(Cuenta entity);
        Task Delete(long id);
        Task<List<Cuenta>> GetAll();

    }
}
