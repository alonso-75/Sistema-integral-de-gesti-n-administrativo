using SistemaAdministrativoAPI.Models.Archivos;
using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoAPI.Models.Gestion_de_Pqrsd
{
    public class Pqrsd
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Radicado { get; set; } = string.Empty;

        [Required]
        public DateTime FechaRecibido { get; set; }

        [Required, MaxLength(255)]
        public string Remitente { get; set; } = string.Empty;

        [Required, MaxLength(255)]
        public string Asunto { get; set; } = string.Empty;

        [Required]
        public int Folios { get; set; }

        [Required, MaxLength(255)]
        public string Razon { get; set; } = string.Empty;

        [Required, MaxLength(255)]
        public string RecibidoPor { get; set; } = string.Empty;

        [Required, MaxLength(255)]
        public string Responsable { get; set; } = string.Empty;

        public DateTime? FechaEntregaResponsable { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaSalida { get; set; }

        [Required, MaxLength(100)]
        public string Estado { get; set; } = string.Empty;

        public int? DiasFaltantes { get; set; }

        [MaxLength(100)]
        public string? Cumplimiento { get; set; }

        [MaxLength(100)]
        public string? Rp { get; set; }

        public string? Observaciones { get; set; }

        public virtual ICollection<Archivo> Archivos { get; set; } = new List<Archivo>();
    }
}
