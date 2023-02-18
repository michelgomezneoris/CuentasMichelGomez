using CuentasMichelGomez.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CuentasMichelGomez.DbContexts
{
    public partial class CuentasDbContext : DbContext
    {
        public CuentasDbContext()
        {

        }

        public CuentasDbContext(DbContextOptions<CuentasDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<TipoCuenta> TipoCuenta { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public DbSet<TipoMovimiento> TipoMovimiento { get; set; }
    }
}
