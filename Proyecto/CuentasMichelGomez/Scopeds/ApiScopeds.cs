using CuentasMichelGomez.Repositories.Clientes;
using CuentasMichelGomez.Repositories.Cuentas;
using CuentasMichelGomez.Repositories.Movimientos;
using CuentasMichelGomez.Repositories.Personas;
using CuentasMichelGomez.Repositories.Reportes;
using CuentasMichelGomez.Repositories.TipoMovimientos;
using CuentasMichelGomez.Services.Clientes;
using CuentasMichelGomez.Services.Cuentas;
using CuentasMichelGomez.Services.Movimientos;
using CuentasMichelGomez.Services.Personas;
using CuentasMichelGomez.Services.Reportes;

namespace CuentasMichelGomez.Scopeds
{
    public static class ApiScopeds
    {
        public static IServiceCollection AddApiScopeds(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<ICuentaService, CuentaService>();

            services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            services.AddScoped<IMovimientoService, MovimientoService>();

            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IPersonaService, PersonaService>();

            services.AddScoped<IReporteRepository, ReporteRepository>();
            services.AddScoped<IReporteService, ReporteService>();

            services.AddScoped<ITipoMovimientoRepository, TipoMovimientoRepository>();

            return services;
        }
    }
}
