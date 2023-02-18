using CuentasMichelGomez.Dtos.Personas;

namespace CuentasMichelGomez.Dtos.Clientes
{
    public class ReadCliente
    {
        public long ClienteId { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public bool? Estado { get; set; }
        public long PersonaId { get; set; }
        public ReadPersona Persona { get; set; }
    }
}
