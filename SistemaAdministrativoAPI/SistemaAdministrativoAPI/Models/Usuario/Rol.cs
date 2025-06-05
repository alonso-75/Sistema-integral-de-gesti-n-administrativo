using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoAPI.Models.Usuario
{
    public class Rol
    {
        [Key]
        public long Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;


        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<RolPermiso> RolesPermisos { get; set; } = new List<RolPermiso>();
    }
}
