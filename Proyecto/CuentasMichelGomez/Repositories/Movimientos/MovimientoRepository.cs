using CuentasMichelGomez.DbContexts;
using CuentasMichelGomez.Models;
using Microsoft.EntityFrameworkCore;

namespace CuentasMichelGomez.Repositories.Movimientos
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly CuentasDbContext _context;

        public MovimientoRepository(CuentasDbContext context)
        {
            _context = context;
        }

        public async Task<Movimiento> Create(Movimiento entity)
        {
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Movimiento> Read(long id)
        {
            var query = _context.Movimiento.Where(x => x.MovimientoId == id);

            query = query.Include(x => x.TipoMovimiento);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Movimiento> Update(Movimiento entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task Delete(long id)
        {
            var entity = await Read(id);
            if (entity != null)
            {
                _context.Movimiento.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Movimiento>> GetAll()
        {
            var query = from Movimiento in _context.Movimiento select Movimiento;

            query = query.Include(x => x.TipoMovimiento);

            return await query.ToListAsync();
        }
    }
}
