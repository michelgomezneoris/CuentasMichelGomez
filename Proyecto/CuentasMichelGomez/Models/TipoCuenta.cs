using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CuentasMichelGomez.Models
{
    [Table(name: "tipo_cuenta")]
    public class TipoCuenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "tipo_cuenta_id")]
        public long TipoCuentaId { get; set; }

        [Column(name: "nombre", TypeName = "Varchar(1024)")]
        public string Nombre { get; set; }

        public ICollection<Cuenta> Cuentas { get; set; }
    }
}
