using SistemaAdministrativoAPI.Models.Gestion_de_Pqrsd;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoAPI.Models.Archivos
{
    public class Archivo
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long PqrsdId { get; set; }

        [ForeignKey("PqrsdId")]
        public virtual Pqrsd Pqrsd { get; set; } = null!;

        [Required, MaxLength(500)]
        public string Link { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Descripcion { get; set; }
    }
}
