using CuentasMichelGomez.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuentasMichelGomez.Dtos.Movimientos
{
    public class CreateMovimiento
    {
        public long TipoMovimientoId { get; set; }
        public DateTime Fecha { get; set; }
        public int Valor { get; set; }
        public long CuentaId { get; set; }
    }
}
