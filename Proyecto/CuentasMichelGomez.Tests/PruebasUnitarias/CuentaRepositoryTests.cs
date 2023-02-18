using CuentasMichelGomez.DbContexts;
using CuentasMichelGomez.Models;
using CuentasMichelGomez.Repositories.Clientes;
using CuentasMichelGomez.Repositories.Cuentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasMichelGomez.Tests.PruebasUnitarias
{
    [TestClass]
    public class CuentaRepositoryTests : BasePruebas
    {
        private readonly string _dbName;
        private readonly CuentasDbContext _memoryContext;

        public CuentaRepositoryTests()
        {
            _dbName = Guid.NewGuid().ToString();
            _memoryContext = BuildContext(_dbName);

            _memoryContext.TipoIdentificacion.Add(new TipoIdentificacion() { TipoIdentificacionId = 1, Nombre = "CC" });
            _memoryContext.TipoCuenta.Add(new TipoCuenta() { TipoCuentaId = 1, Nombre = "Ahorros" });
            _memoryContext.Persona.Add(new Persona() { Direccion = "Calle 11 no 11 11", Edad = 19, Genero = "Femenino", Identificacion = "123", Nombre = "Maria Lopez", PersonaId = 1, Telefono = "123", TipoIdentificacionId = 1 });
            _memoryContext.Persona.Add(new Persona() { Direccion = "Calle 22 no 22 22", Edad = 34, Genero = "Masculino", Identificacion = "778", Nombre = "Jose Romero", PersonaId = 2, Telefono = "123222", TipoIdentificacionId = 1 });
            _memoryContext.Cliente.Add(new Cliente() { ClienteId = 1, Estado = true, Usuario = "Usuario1", Password = "123", PersonaId = 1 });
            _memoryContext.Cliente.Add(new Cliente() { ClienteId = 2, Estado = true, Usuario = "Usuario2", Password = "456", PersonaId = 2 });
            _memoryContext.Cuenta.Add(new Cuenta() { CuentaId = 1, ClienteId = 1, Estado = true, NumeroCuenta = "123", Saldo = 500, TipoCuentaId = 1 });
            _memoryContext.SaveChanges();
        }

        [TestMethod]
        public async Task CreateOk()
        {
            // Prepare
            var context = BuildContext(_dbName);

            // Test
            var repository = new CuentaRepository(context);
            var cuenta = new Cuenta() { ClienteId = 1, Estado = true, NumeroCuenta = "123", Saldo = 500, TipoCuentaId = 1 };
            var entity = await repository.Create(cuenta);

            // Result
            var result = entity != null;

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task ReadOk()
        {
            // Prepare
            var context = BuildContext(_dbName);

            // Test
            var repository = new CuentaRepository(context);
            var entity = await repository.Read(1);

            // Result
            var result = entity != null;

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task ReadNotFound()
        {
            // Prepare
            var context = BuildContext(_dbName);

            // Test
            var repository = new CuentaRepository(context);
            var entity = await repository.Read(3);

            // Result
            var result = entity == null;

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task UpdateOk()
        {
            // Prepare
            var context = BuildContext(_dbName);

            // Test
            var repository = new CuentaRepository(context);
            var cuenta = new Cuenta() { CuentaId = 1, ClienteId = 1, Estado = true, NumeroCuenta = "123", Saldo = 800, TipoCuentaId = 1 };
            var entity = await repository.Update(cuenta);

            // Result
            var result = entity.Saldo == 800;

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task GetAllOk()
        {
            // Prepare
            var context = BuildContext(_dbName);

            // Test
            var repository = new CuentaRepository(context);
            var entity = await repository.GetAll();

            // Result
            var result = entity.Count() == 1;

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task GetAllBad()
        {
            // Prepare
            var context = BuildContext(_dbName);

            // Test
            var repository = new CuentaRepository(context);
            var entity = await repository.GetAll();

            // Result
            var result = entity.Count() != 1;

            Assert.AreEqual(false, result);
        }
    }
}
