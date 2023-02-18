using CuentasMichelGomez.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuentasMichelGomez.Dtos.Reportes
{
    public class ReadReporte
    {
        public long MovimientoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public string Estado { get; set; }
        public int SaldoInicial { get; set; }
        public int Movimiento { get; set; }
        public int Saldo { get; set; }
    }
}
