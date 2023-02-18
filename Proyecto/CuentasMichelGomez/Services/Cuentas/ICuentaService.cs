using CuentasMichelGomez.Dtos.Cuentas;

namespace CuentasMichelGomez.Services.Cuentas
{
    public interface ICuentaService
    {
        Task<ReadCuenta> Create(CreateCuenta createRequest);
        Task<ReadCuenta> Read(long id);
        Task<ReadCuenta> Update(UpdateCuenta updateRequest);
        Task Delete(long id);
        Task<ICollection<ReadCuenta>> GetAll();

    }
}
