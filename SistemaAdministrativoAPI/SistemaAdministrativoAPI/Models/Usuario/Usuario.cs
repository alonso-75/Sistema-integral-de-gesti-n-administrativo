using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoAPI.Models.Usuario
{
    public class Usuario
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(100)]
        public string UsuarioNombre { get; set; } = string.Empty;

        [Required, MaxLength(255)]
        public string Nombre { get; set; } = string.Empty;

        [Required, MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(255)]
        public string Clave { get; set; } = string.Empty;

        [Required]
        public long RolId { get; set; }

        [MaxLength(100)]
        public string? Cargo { get; set; }

        [ForeignKey("RolId")]
        public virtual Rol Rol { get; set; } = null!;
    }
}

