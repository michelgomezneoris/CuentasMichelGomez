using CuentasMichelGomez.Dtos.Movimientos;

namespace CuentasMichelGomez.Services.Movimientos
{
    public interface IMovimientoService
    {
        Task<ReadMovimiento> Create(CreateMovimiento createRequest);
        Task<ReadMovimiento> Read(long id);
        Task<ReadMovimiento> Update(UpdateMovimiento updateRequest);
        Task Delete(long id);
        Task<ICollection<ReadMovimiento>> GetAll();
        Task<bool> HasSaldo(CreateMovimiento createRequest);
    }
}
