using AutoMapper;
using CuentasMichelGomez.DbContexts;
using CuentasMichelGomez.Dtos.Clientes.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasMichelGomez.Tests.PruebasUnitarias
{
    public class BasePruebas
    {
        protected CuentasDbContext BuildContext(string dbName)
        {
            var opciones = new DbContextOptionsBuilder<CuentasDbContext>()
                .UseInMemoryDatabase(dbName).Options;

            var dbContext = new CuentasDbContext(opciones);
            return dbContext;
        }

        protected IMapper ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile(new ReadClienteMapping());
            });

            return config.CreateMapper();
        }
    }
}
