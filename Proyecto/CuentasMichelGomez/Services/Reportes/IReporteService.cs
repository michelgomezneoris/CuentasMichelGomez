using CuentasMichelGomez.Dtos.Reportes;

namespace CuentasMichelGomez.Services.Reportes
{
    public interface IReporteService
    {
        Task<ICollection<ReadReporte>> GetAll(GetAllReporte getAllRequest);
    }
}
