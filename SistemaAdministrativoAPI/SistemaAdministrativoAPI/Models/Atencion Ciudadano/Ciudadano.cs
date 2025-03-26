using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoAPI.Models.Atencion_Ciudadano
{
    public class Ciudadano
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string? TipoDocumento { get; set; }

        [Required, MaxLength(20)]
        public string? NumeroDocumento { get; set; }

        [Required, MaxLength(50)]
        public string? PrimerNombre { get; set; }

        [MaxLength(50)]
        public string? SegundoNombre { get; set; }

        [Required, MaxLength(50)]
        public string? PrimerApellido { get; set; }

        [MaxLength(50)]
        public string? SegundoApellido { get; set; }

        [Required, MaxLength(20)]
        public string? Genero { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(100)]
        public string? PertenenciaEtnica { get; set; }

        [MaxLength(100)]
        public string? TipoPoblacion { get; set; }

        [MaxLength(100), EmailAddress]
        public string? CorreoElectronico { get; set; }

        [MaxLength(100)]
        public string? TelefonosContacto { get; set; }

        [MaxLength(255)]
        public string? Direccion { get; set; }

        public ICollection<Atencion> Atenciones { get; set; } = new List<Atencion>();

    }
}
