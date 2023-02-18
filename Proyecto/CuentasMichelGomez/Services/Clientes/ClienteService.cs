using AutoMapper;
using CuentasMichelGomez.Dtos.Clientes;
using CuentasMichelGomez.Models;
using CuentasMichelGomez.Repositories.Clientes;

namespace CuentasMichelGomez.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReadCliente> Create(CreateCliente createRequest)
        {
            Cliente entity = _mapper.Map<CreateCliente, Cliente>(createRequest);
            entity = await _repository.Create(entity);
            ReadCliente dto = _mapper.Map<Cliente, ReadCliente>(entity);
            return dto;
        }
        public async Task<ReadCliente> Read(long id)
        {
            Cliente entity = await _repository.Read(id);
            var dto = _mapper.Map<Cliente, ReadCliente>(entity);
            return dto;
        }
        public async Task<ReadCliente> Update(UpdateCliente updateRequest)
        {
            Cliente entity = await _repository.Read(updateRequest.ClienteId);
            entity = _mapper.Map<UpdateCliente, Cliente>(updateRequest, entity);
            entity = await _repository.Update(entity);
            ReadCliente dto = _mapper.Map<Cliente, ReadCliente>(entity);
            return dto;
        }

        public async Task Delete(long id)
        {
            await _repository.Delete(id);
        }


        public async Task<ICollection<ReadCliente>> GetAll()
        {
            List<Cliente> entities = await _repository.GetAll();
            var dtos = _mapper.Map<List<Cliente>, List<ReadCliente>>(entities);

            return dtos;
        }

    }
}
