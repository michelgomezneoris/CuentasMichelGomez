using CuentasMichelGomez.Dtos.Reportes;
using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Repositories.Reportes
{
    public interface IReporteRepository
    {
        Task<List<Movimiento>> GetAll(GetAllReporte getAllRequest);
    }
}
