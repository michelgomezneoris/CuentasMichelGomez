using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CuentasMichelGomez.Models
{
    [Table(name: "tipo_movimiento")]
    public class TipoMovimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "tipo_movimiento_id")]
        public long TipoMovimientoId { get; set; }

        [Column(name: "nombre", TypeName = "Varchar(1024)")]
        public string Nombre { get; set; }

        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
