using CuentasMichelGomez.Models;

namespace CuentasMichelGomez.Repositories.Personas
{
    public interface IPersonaRepository
    {
        Task<Persona> Create(Persona entity);
        Task<Persona> Read(long id);
        Task<Persona> Update(Persona entity);
        Task Delete(long id);
        Task<List<Persona>> GetAll();

    }
}
