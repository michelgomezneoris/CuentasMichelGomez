using AutoMapper;
using CuentasMichelGomez.Dtos.Movimientos;
using CuentasMichelGomez.Models;
using CuentasMichelGomez.Repositories.Cuentas;
using CuentasMichelGomez.Repositories.Movimientos;
using CuentasMichelGomez.Repositories.TipoMovimientos;

namespace CuentasMichelGomez.Services.Movimientos
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _repository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly ITipoMovimientoRepository _tipoMovimientoRepository;
        private readonly IMapper _mapper;
        public MovimientoService(IMovimientoRepository repository, ICuentaRepository cuentaRepository, ITipoMovimientoRepository tipoMovimientoRepository, IMapper mapper)
        {
            _repository = repository;
            _cuentaRepository = cuentaRepository;
            _tipoMovimientoRepository = tipoMovimientoRepository;
            _mapper = mapper;
        }
        public async Task<ReadMovimiento> Create(CreateMovimiento createRequest)
        {
            Movimiento entity = _mapper.Map<CreateMovimiento, Movimiento>(createRequest);
            entity = await _repository.Create(entity);
            ReadMovimiento dto = _mapper.Map<Movimiento, ReadMovimiento>(entity);
            return dto;
        }
        public async Task<ReadMovimiento> Read(long id)
        {
            Movimiento entity = await _repository.Read(id);
            var dto = _mapper.Map<Movimiento, ReadMovimiento>(entity);
            return dto;
        }
        public async Task<ReadMovimiento> Update(UpdateMovimiento updateRequest)
        {
            Movimiento entity = await _repository.Read(updateRequest.MovimientoId);
            entity = _mapper.Map<UpdateMovimiento, Movimiento>(updateRequest, entity);
            entity = await _repository.Update(entity);
            ReadMovimiento dto = _mapper.Map<Movimiento, ReadMovimiento>(entity);
            return dto;
        }

        public async Task Delete(long id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<ReadMovimiento>> GetAll()
        {
            List<Movimiento> entities = await _repository.GetAll();
            var dtos = _mapper.Map<List<Movimiento>, List<ReadMovimiento>>(entities);

            return dtos;
        }

        public async Task<bool> HasSaldo(CreateMovimiento createRequest)
        {
            Cuenta cuenta = await _cuentaRepository.Read(createRequest.CuentaId);
            var tipoMovimiento = await _tipoMovimientoRepository.Read(createRequest.TipoMovimientoId);
            var isDeposito = tipoMovimiento.Nombre.ToUpper() == "DEPOSITO";

            if(isDeposito)
            {
                return true;
            }

            return cuenta.Saldo - createRequest.Valor >= 0;
        }

    }
}
