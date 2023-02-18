using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CuentasMichelGomez.Models
{
    [Table(name: "tipo_identificacion")]
    public class TipoIdentificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "tipo_identificacion_id")]
        public long TipoIdentificacionId { get; set; }

        [Column(name: "nombre", TypeName = "Varchar(1024)")]
        public string Nombre { get; set; }

        public ICollection<Persona> Personas { get; set; }
    }
}
