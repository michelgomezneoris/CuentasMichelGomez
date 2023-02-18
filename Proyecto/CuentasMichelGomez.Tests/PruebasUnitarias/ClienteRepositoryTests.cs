using CuentasMichelGomez.DbContexts;
using CuentasMichelGomez.Models;
using CuentasMichelGomez.Repositories.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentasMichelGomez.Tests.PruebasUnitarias
{
    [TestClass]
    public class ClienteRepositoryTests : BasePruebas
    {
        private readonly string _dbName;
        private readonly CuentasDbContext _memoryContext;

        public ClienteRepositoryTests()
        {
            _dbName = Guid.NewGuid().ToString();
            _memoryContext = BuildContext(_dbName);

            _memoryContext.TipoIdentificacion.Add(new TipoIdentificacion() { TipoIdentificacionId = 1, Nombre = "CC" });
            _memoryContext.Persona.Add(new Persona() { Direccion = "Calle 11 no 11 11", Edad = 19, Genero = "Femenino", Identificacion = "123", Nombre = "Maria Lopez", PersonaId = 1, Telefono = "123", TipoIdentificacionId = 1 });
            _memoryContext.Cliente.Add(new Cliente() { ClienteId = 1, Estado = true, Usuario = "Usuario1", Password = "123", PersonaId = 1 });
            _memoryContext.Cliente.Add(new Cliente() { ClienteId = 2, Estado = true, Usuario = "Usuario2", Password = "456", PersonaId = 2 });
            _memoryContext.SaveChanges();
        }

        [TestMethod]
        public async Task CreateOk()
        {
            // Prepare
            var context = BuildContext(_dbName);

            // Test
            var repository = new ClienteRepository(context);
            var persona = new Persona() { Direccion = "Calle 11 no 11 11", Edad = 19, Genero = "Femenino", Identificacion = "123", Nombre = "Lorena Lopez", Telefono = "123", TipoIdentificacionId = 1 };
            var cliente = new Cliente() { Estado = true, Usuario = "Usuario1", Password = "123", Persona = persona };
            var entity = await repository.Create(cliente);

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
            var repository = new ClienteRepository(context);
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
            var repository = new ClienteRepository(context);
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
            var repository = new ClienteRepository(context);
            var persona = new Persona() { PersonaId = 1, Direccion = "Calle 11 no 11 11", Edad = 19, Genero = "Femenino", Identificacion = "123", Nombre = "Lorena Lopez", Telefono = "123", TipoIdentificacionId = 1 };
            var cliente = new Cliente() { ClienteId = 1, Estado = true, Usuario = "Usuario1", Password = "1234", PersonaId = 1, Persona = persona };
            var entity = await repository.Update(cliente);

            // Result
            var result = entity != null;

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task GetAllOk()
        {
            // Prepare
            var context = BuildContext(_dbName);

            // Test
            var repository = new ClienteRepository(context);
            var entity = await repository.GetAll();

            // Result
            var result = entity.Count() == 2;

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public async Task GetAllBad()
        {
            // Prepare
            var context = BuildContext(_dbName);

            // Test
            var repository = new ClienteRepository(context);
            var entity = await repository.GetAll();

            // Result
            var result = entity.Count() != 2;

            Assert.AreEqual(false, result);
        }
    }
}
