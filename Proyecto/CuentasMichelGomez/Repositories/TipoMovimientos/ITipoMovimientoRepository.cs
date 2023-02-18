using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Repositories.TipoMovimientos
{
    public interface ITipoMovimientoRepository
    {
        Task<TipoMovimiento> Create(TipoMovimiento entity);
        Task<TipoMovimiento> Read(long id);
        TipoMovimiento ReadSync(long id);
        Task<TipoMovimiento> Update(TipoMovimiento entity);
        Task Delete(long id);
        Task<List<TipoMovimiento>> GetAll();

    }
}
