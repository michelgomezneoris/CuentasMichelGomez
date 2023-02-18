using CuentasMichelGomez.DbContexts;
using CuentasMichelGomez.Models;
using Microsoft.EntityFrameworkCore;

namespace CuentasMichelGomez.Repositories.Cuentas
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly CuentasDbContext _context;

        public CuentaRepository(CuentasDbContext  context)
        {
            _context = context;
        }

        public async Task<Cuenta> Create(Cuenta entity)
        {
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Cuenta> Read(long id)
        {
            return await _context.Cuenta.Where(x => x.CuentaId == id).FirstOrDefaultAsync();
        }

        public Cuenta ReadSync(long id)
        {
            return _context.Cuenta.Where(x => x.CuentaId == id).FirstOrDefault();
        }

        public async Task<Cuenta> Update(Cuenta entity)
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
                _context.Cuenta.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Cuenta>> GetAll()
        {
            var query = from Cuenta in _context.Cuenta select Cuenta;

            return await query.ToListAsync();
        }
    }
}
