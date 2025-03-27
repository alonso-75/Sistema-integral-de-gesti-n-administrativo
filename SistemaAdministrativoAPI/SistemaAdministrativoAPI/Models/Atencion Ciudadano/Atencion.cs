using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoAPI.Models.Atencion_Ciudadano
{
    public class Atencion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CiudadanoId { get; set; }

        [Required, MaxLength(100)]
        public string? TipoAtencion { get; set; }

        [Required]
        public DateTime FechaAtencion { get; set; } = DateTime.UtcNow;

        [Required, MaxLength(255)]
        public string? Asunto { get; set; }

        public string? Descripcion { get; set; }

        [Required, MaxLength(100)]
        public string? AtendidoPor { get; set; }

        [Required, MaxLength(255)]
        public string? DependenciaAtiende { get; set; }

        [Required, MaxLength(255)]
        public string? OficinaProgramaAtiende { get; set; }
    }
}
