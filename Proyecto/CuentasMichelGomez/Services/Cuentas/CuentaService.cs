using AutoMapper;
using CuentasMichelGomez.Dtos.Cuentas;
using CuentasMichelGomez.Models;
using CuentasMichelGomez.Repositories.Cuentas;

namespace CuentasMichelGomez.Services.Cuentas
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _repository;
        private readonly IMapper _mapper;
        public CuentaService(ICuentaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReadCuenta> Create(CreateCuenta createRequest)
        {
            Cuenta entity = _mapper.Map<CreateCuenta, Cuenta>(createRequest);
            entity = await _repository.Create(entity);
            ReadCuenta dto = _mapper.Map<Cuenta, ReadCuenta>(entity);
            return dto;
        }
        public async Task<ReadCuenta> Read(long id)
        {
            Cuenta entity = await _repository.Read(id);
            var dto = _mapper.Map<Cuenta, ReadCuenta>(entity);
            return dto;
        }
        public async Task<ReadCuenta> Update(UpdateCuenta updateRequest)
        {
            Cuenta entity = await _repository.Read(updateRequest.CuentaId);
            entity = _mapper.Map<UpdateCuenta, Cuenta>(updateRequest, entity);
            entity = await _repository.Update(entity);
            ReadCuenta dto = _mapper.Map<Cuenta, ReadCuenta>(entity);
            return dto;
        }

        public async Task Delete(long id)
        {
            await _repository.Delete(id);
        }


        public async Task<ICollection<ReadCuenta>> GetAll()
        {
            List<Cuenta> entities = await _repository.GetAll();
            var dtos = _mapper.Map<List<Cuenta>, List<ReadCuenta>>(entities);

            return dtos;
        }

    }
}
