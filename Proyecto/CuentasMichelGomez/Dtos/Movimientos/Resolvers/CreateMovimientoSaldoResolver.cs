using AutoMapper;
using CuentasMichelGomez.Dtos.Movimientos;
using CuentasMichelGomez.Models;
using CuentasMichelGomez.Repositories.Cuentas;
using CuentasMichelGomez.Repositories.TipoMovimientos;

namespace CuentasMichelGomez.Dtos.Movimientos.Resolvers
{
    public class CreateMovimientoSaldoResolver : IValueResolver<CreateMovimiento, Movimiento, int>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly ITipoMovimientoRepository _tipoMovimientoRepository;

        public CreateMovimientoSaldoResolver(ICuentaRepository cuentaRepository, ITipoMovimientoRepository tipoMovimientoRepository)
        {
            _cuentaRepository = cuentaRepository;
            _tipoMovimientoRepository = tipoMovimientoRepository;
        }

        public int Resolve(CreateMovimiento source, Movimiento destination, int destMember, ResolutionContext context)
        {
            var tipoMovimiento = _tipoMovimientoRepository.ReadSync(source.TipoMovimientoId);
            var cuenta = _cuentaRepository.ReadSync(source.CuentaId);
            var isDeposito = tipoMovimiento.Nombre.ToUpper() == "DEPOSITO";
            var saldo = isDeposito ? cuenta.Saldo + source.Valor : cuenta.Saldo - source.Valor;

            destination.SaldoInicial = cuenta.Saldo;
            cuenta.Saldo = saldo;
            destination.Cuenta = cuenta;

            return saldo;
        }
    }
}