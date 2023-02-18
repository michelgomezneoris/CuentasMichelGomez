using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuentasMichelGomez.Models
{
    [Table(name: "movimiento")]
    public class Movimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "movimiento_id")]
        public long MovimientoId { get; set; }

        [Column(name: "tipo_movimiento_id")]
        public long TipoMovimientoId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }

        [Column(name: "fecha", TypeName = "date")]
        public DateTime Fecha { get; set; }

        [Column(name: "saldo_inicial")]
        public int SaldoInicial { get; set; }

        [Column(name: "valor")]
        public int Valor { get; set; }

        [Column(name: "saldo")]
        public int Saldo { get; set; }

        [Column(name: "cuenta_id")]
        public long CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}
