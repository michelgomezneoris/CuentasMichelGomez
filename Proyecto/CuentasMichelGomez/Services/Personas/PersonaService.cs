using AutoMapper;
using CuentasMichelGomez.Dtos.Personas;
using CuentasMichelGomez.Models;
using CuentasMichelGomez.Repositories.Personas;

namespace CuentasMichelGomez.Services.Personas
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _repository;
        private readonly IMapper _mapper;
        public PersonaService(IPersonaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReadPersona> Create(CreatePersona createRequest)
        {
            Persona entity = _mapper.Map<CreatePersona, Persona>(createRequest);
            entity = await _repository.Create(entity);
            ReadPersona dto = _mapper.Map<Persona, ReadPersona>(entity);
            return dto;
        }
        public async Task<ReadPersona> Read(long id)
        {
            Persona entity = await _repository.Read(id);
            var dto = _mapper.Map<Persona, ReadPersona>(entity);
            return dto;
        }
        public async Task<ReadPersona> Update(UpdatePersona updateRequest)
        {
            Persona entity = await _repository.Read(updateRequest.PersonaId);
            entity = _mapper.Map<UpdatePersona, Persona>(updateRequest, entity);
            entity = await _repository.Update(entity);
            ReadPersona dto = _mapper.Map<Persona, ReadPersona>(entity);
            return dto;
        }

        public async Task Delete(long id)
        {
            await _repository.Delete(id);
        }


        public async Task<ICollection<ReadPersona>> GetAll()
        {
            List<Persona> entities = await _repository.GetAll();
            var dtos = _mapper.Map<List<Persona>, List<ReadPersona>>(entities);

            return dtos;
        }

    }
}
