using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Repositories.Movimientos
{
    public interface IMovimientoRepository
    {
        Task<Movimiento> Create(Movimiento entity);
        Task<Movimiento> Read(long id);
        Task<Movimiento> Update(Movimiento entity);
        Task Delete(long id);
        Task<List<Movimiento>> GetAll();

    }
}
