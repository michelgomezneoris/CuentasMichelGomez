using CuentasMichelGomez.DbContexts;
using CuentasMichelGomez.Models;
using Microsoft.EntityFrameworkCore;

namespace CuentasMichelGomez.Repositories.Personas
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly CuentasDbContext _context;

        public PersonaRepository(CuentasDbContext context)
        {
            _context = context;
        }

        public async Task<Persona> Create(Persona entity)
        {
            var result = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Persona> Read(long id)
        {
            return await _context.Persona.Where(x => x.PersonaId == id).FirstOrDefaultAsync();
        }

        public async Task<Persona> Update(Persona entity)
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
                _context.Persona.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Persona>> GetAll()
        {
            var query = from Persona in _context.Persona select Persona;

            return await query.ToListAsync();
        }
    }
}
