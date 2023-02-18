using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CuentasMichelGomez.Models
{
    [Table(name: "cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "cliente_id")]
        public long ClienteId { get; set; }

        [Column(name: "usuario")]
        public string Usuario { get; set; }

        [Column(name: "password")]
        public string Password { get; set; }

        [Column(name: "estado")]
        public bool? Estado { get; set; }

        [Column(name: "persona_id")]
        public long PersonaId { get; set; }
        public Persona? Persona { get; set; }

        public ICollection<Cuenta> Cuentas { get; set; }
    }
}