using CuentasMichelGomez.Dtos.Personas;

namespace CuentasMichelGomez.Services.Personas
{
    public interface IPersonaService
    {
        Task<ReadPersona> Create(CreatePersona createRequest);
        Task<ReadPersona> Read(long id);
        Task<ReadPersona> Update(UpdatePersona updateRequest);
        Task Delete(long id);
        Task<ICollection<ReadPersona>> GetAll();

    }
}
