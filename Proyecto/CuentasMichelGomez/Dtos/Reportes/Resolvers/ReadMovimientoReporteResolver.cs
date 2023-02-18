using AutoMapper;
using CuentasMichelGomez.Dtos.Movimientos;
using CuentasMichelGomez.Dtos.Reportes;
using CuentasMichelGomez.Models;
using CuentasMichelGomez.Repositories.Cuentas;
using CuentasMichelGomez.Repositories.TipoMovimientos;

namespace CuentasMichelGomez.Dtos.Movimientos.Resolvers
{
    public class ReadMovimientoReporteResolver : IValueResolver<Movimiento, ReadReporte, long>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly ITipoMovimientoRepository _tipoMovimientoRepository;

        public ReadMovimientoReporteResolver(ICuentaRepository cuentaRepository, ITipoMovimientoRepository tipoMovimientoRepository)
        {
            _cuentaRepository = cuentaRepository;
            _tipoMovimientoRepository = tipoMovimientoRepository;
        }

        public long Resolve(Movimiento source, ReadReporte destination, long destMember, ResolutionContext context)
        {
            destination.Estado = source.Cuenta.Estado ? "ACTIVA" : "INACTIVA";
            destination.Fecha = source.Fecha;
            destination.Nombre = source.Cuenta.Cliente.Persona.Nombre;
            destination.NumeroCuenta = source.Cuenta.NumeroCuenta;
            destination.Saldo = source.Saldo;
            destination.SaldoInicial = source.SaldoInicial;
            destination.TipoCuenta = source.Cuenta.TipoCuenta.Nombre;
            destination.Movimiento = source.TipoMovimiento.Nombre.ToUpper() == "DEPOSITO" ? source.Valor : source.Valor * -1;

            return source.MovimientoId;
        }
    }
}