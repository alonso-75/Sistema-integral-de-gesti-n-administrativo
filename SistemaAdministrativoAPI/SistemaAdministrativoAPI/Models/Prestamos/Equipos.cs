using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoAPI.Models.Prestamos
{
    public class Equipos
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? NombreEquipo { get; set; }

        public string? DescripcionEquipo { get; set; }

        [Required]
        [StringLength(20)]
        public string? EstadoEquipo { get; set; } // 'Disponible', 'Prestado', 'En reparación', 'Fuera de servicio'

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
    }
}
