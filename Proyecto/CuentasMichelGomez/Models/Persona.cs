using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuentasMichelGomez.Models
{
    [Table(name: "persona")]
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "persona_id")]
        public long PersonaId { get; set; }

        [Column(name: "nombre", TypeName = "Varchar(1024)")]
        public string Nombre { get; set; }

        [Column(name: "genero", TypeName = "Varchar(1024)")]
        public string Genero { get; set; }

        [Column(name: "edad")]
        public int Edad { get; set; }

        [Column(name: "tipo_identificacion_id")]
        public long TipoIdentificacionId { get; set; }
        public TipoIdentificacion TipoIdentificacion { get; set; }

        [Column(name: "identificacion", TypeName = "Varchar(1024)")]
        public string Identificacion { get; set; }

        [Column(name: "direccion", TypeName = "Varchar(1024)")]
        public string Direccion { get; set; }

        [Column(name: "telefono", TypeName = "Varchar(1024)")]
        public string Telefono { get; set; }

        public Cliente Cliente { get; set; }
    }
}
