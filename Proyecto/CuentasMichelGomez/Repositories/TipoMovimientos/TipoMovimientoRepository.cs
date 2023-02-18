using CuentasMichelGomez.DbContexts;
using CuentasMichelGomez.Models;
using Microsoft.EntityFrameworkCore;

namespace CuentasMichelGomez.Repositories.TipoMovimientos
{
    public class TipoMovimientoRepository : ITipoMovimientoRepository
    {
        private readonly CuentasDbContext _context;

        public TipoMovimientoRepository(CuentasDbContext context)
        {
            _context = context;
        }

        public async Task<TipoMovimiento> Create(TipoMovimiento entity)
        {
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TipoMovimiento> Read(long id)
        {
            return await _context.TipoMovimiento.Where(x => x.TipoMovimientoId == id).FirstOrDefaultAsync();
        }

        public TipoMovimiento ReadSync(long id)
        {
            return _context.TipoMovimiento.Where(x => x.TipoMovimientoId == id).FirstOrDefault();
        }

        public async Task<TipoMovimiento> Update(TipoMovimiento entity)
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
                _context.TipoMovimiento.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TipoMovimiento>> GetAll()
        {
            var query = from TipoMovimiento in _context.TipoMovimiento select TipoMovimiento;

            return await query.ToListAsync();
        }
    }
}
