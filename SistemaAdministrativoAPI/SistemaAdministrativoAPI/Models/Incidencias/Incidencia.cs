using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace SistemaAdministrativoAPI.Models.Incidencias
{
    public class Incidencia
    {
        [Key]
        public int Id { get; set; } // Número de referencia

        [Required, MaxLength(200)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public DateTime FechaIncidencia { get; set; }

        [Required]
        public TimeSpan HoraIncidencia { get; set; }

        [Required, MaxLength(255)]
        public string Ubicacion { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Departamento { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string TipoIncidencia { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string NivelSeveridad { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Descripcion { get; set; } = string.Empty;

        public List<string> PersonasInvolucradas { get; set; } = new();
        public List<string> Testigos { get; set; } = new();

        // Relación con Evidencias
        public virtual ICollection<Evidencia> Evidencias { get; set; } = new List<Evidencia>();
    }
}
