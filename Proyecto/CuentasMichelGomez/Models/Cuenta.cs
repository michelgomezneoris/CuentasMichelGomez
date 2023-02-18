using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CuentasMichelGomez.Models
{
    [Table(name: "cuenta")]
    public class Cuenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "cuenta_id")]
        public long CuentaId { get; set; }

        [Column(name: "tipo_cuenta_id")]
        public long TipoCuentaId { get; set; }
        public TipoCuenta TipoCuenta { get; set; }

        [Column(name: "numero_cuenta", TypeName = "Varchar(1024)")]
        public string NumeroCuenta { get; set; }

        [Column(name: "saldo")]
        public int Saldo { get; set; }

        [Column(name: "estado")]
        public bool Estado { get; set; }

        [Column(name: "cliente_id")]
        public long ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
