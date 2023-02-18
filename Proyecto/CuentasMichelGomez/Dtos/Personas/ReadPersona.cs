using CuentasMichelGomez.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuentasMichelGomez.Dtos.Personas
{
    public class ReadPersona
    {
        public long PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public long TipoIdentificacionId { get; set; }
        public string TipoIdentificacionNombre { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
