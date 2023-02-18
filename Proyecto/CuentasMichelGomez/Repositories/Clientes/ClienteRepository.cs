using CuentasMichelGomez.DbContexts;
using CuentasMichelGomez.Models;
using Microsoft.EntityFrameworkCore;

namespace CuentasMichelGomez.Repositories.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CuentasDbContext _context;

        public ClienteRepository(CuentasDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Create(Cliente entity)
        {
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Cliente> Read(long id)
        {
            var query = _context.Cliente.Where(x => x.ClienteId == id);

            query = query.AsSplitQuery().Include(x => x.Persona).ThenInclude(x => x.TipoIdentificacion);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente> ReadByIdentificacion(string identificacion)
        {
            var query = _context.Cliente.Where(x => x.Persona.Identificacion == identificacion);

            query = query.Include(x => x.Persona).ThenInclude(x => x.TipoIdentificacion);
            query = query.Include(x => x.Cuentas).ThenInclude(x => x.TipoCuenta);
            query = query.Include(x => x.Cuentas).ThenInclude(x => x.Movimientos).ThenInclude(x => x.TipoMovimiento);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente> Update(Cliente entity)
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
                _context.Cliente.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Cliente>> GetAll()
        {
            var query = from Cliente in _context.Cliente select Cliente;

            return await query.ToListAsync();
        }
    }
}
