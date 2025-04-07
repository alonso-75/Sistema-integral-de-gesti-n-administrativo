using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoAPI.Models.Incidencias
{
    public class Evidencia
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string NombreArchivo { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string RutaArchivo { get; set; } = string.Empty; // Ruta donde se almacena el archivo

        [Required]
        public DateTime FechaSubida { get; set; } = DateTime.UtcNow;

        // Clave foránea para vincular con Incidencia
        [Required]
        public int IncidenciaId { get; set; }

        [ForeignKey("IncidenciaId")]
        public virtual Incidencia Incidencia { get; set; } = null!;
    }
}
