using CuentasMichelGomez.Dtos.Personas;

namespace CuentasMichelGomez.Dtos.Clientes
{
    public class CreateCliente
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public bool? Estado { get; set; }
        public CreatePersona Persona { get; set; }
    }
}
