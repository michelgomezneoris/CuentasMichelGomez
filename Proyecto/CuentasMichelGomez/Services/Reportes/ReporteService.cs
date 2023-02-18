using AutoMapper;
using CuentasMichelGomez.Dtos.Reportes;
using CuentasMichelGomez.Models;
using CuentasMichelGomez.Repositories.Clientes;
using CuentasMichelGomez.Repositories.Movimientos;
using CuentasMichelGomez.Repositories.Reportes;

namespace CuentasMichelGomez.Services.Reportes
{
    public class ReporteService : IReporteService
    {
        private readonly IReporteRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly IMapper _mapper;

        public ReporteService(IReporteRepository repository, IMovimientoRepository movimientoRepository, IMapper mapper)
        {
            _repository = repository;
            _movimientoRepository = movimientoRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<ReadReporte>> GetAll(GetAllReporte getAllRequest)
        {
            List<Movimiento> entities = await _repository.GetAll(getAllRequest);
            var dtos = _mapper.Map<List<Movimiento>, List<ReadReporte>>(entities);

            return dtos;
        }

    }
}
