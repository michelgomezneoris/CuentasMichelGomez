using CuentasMichelGomez.DbContexts;
using CuentasMichelGomez.Dtos.Reportes;
using CuentasMichelGomez.Models;
using Microsoft.EntityFrameworkCore;

namespace CuentasMichelGomez.Repositories.Reportes
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly CuentasDbContext _context;

        public ReporteRepository(CuentasDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movimiento>> GetAll(GetAllReporte getAllRequest)
        {
            var query = from Movimiento in _context.Movimiento select Movimiento;

            if (getAllRequest.Identificacion != null)
            {
                query = query.Where(x => x.Cuenta.Cliente.Persona.Identificacion == getAllRequest.Identificacion);
            }
            if (getAllRequest.FechaInicial != null)
            {
                query = query.Where(x => x.Fecha.Date >= getAllRequest.FechaInicial.Value.Date);
            }
            if (getAllRequest.FechaFin != null)
            {
                query = query.Where(x => x.Fecha.Date <= getAllRequest.FechaFin.Value.Date);
            }

            query = query.Include(x => x.Cuenta).ThenInclude(x => x.Cliente).ThenInclude(x => x.Persona).ThenInclude(x => x.TipoIdentificacion);
            query = query.Include(x => x.Cuenta).ThenInclude(x => x.TipoCuenta);
            query = query.Include(x => x.TipoMovimiento);

            return await query.ToListAsync();
        }
    }
}
