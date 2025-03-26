using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoAPI.Models.Prestamos
{
    public class Prestamos_equipos
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long EquipoId { get; set; }

        [ForeignKey("EquipoId")]
        public Equipos? Equipo { get; set; } // Relación con la entidad Equipo

        [Required]
        public DateTime FechaPrestamo { get; set; }

        public DateTime? FechaDevolucion { get; set; }

        [Required]
        [StringLength(100)]
        public string? PrestadoA { get; set; }

        [StringLength(50)]
        public string? ContactoPrestatario { get; set; }

        [Required]
        [StringLength(20)]
        public string? EstadoPrestamo { get; set; } // 'Pendiente', 'En curso', 'Devuelto', 'Retrasado'

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
    }
}
