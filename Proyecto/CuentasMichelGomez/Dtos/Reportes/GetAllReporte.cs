using CuentasMichelGomez.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuentasMichelGomez.Dtos.Reportes
{
    public class GetAllReporte
    {
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Identificacion { get; set; }
    }
}
