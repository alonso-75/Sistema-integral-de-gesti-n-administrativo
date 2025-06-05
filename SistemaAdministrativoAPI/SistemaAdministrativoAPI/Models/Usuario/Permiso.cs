using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoAPI.Models.Usuario
{
    public class Permiso
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<RolPermiso> RolesPermisos { get; set; } = new List<RolPermiso>();
    }
}
