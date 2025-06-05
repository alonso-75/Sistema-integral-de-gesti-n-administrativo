using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaAdministrativoAPI.Models.Usuario
{
    public class RolPermiso
    {
        public long RolId { get; set; }
        public long PermisoId { get; set; }

        [ForeignKey("RolId")]
        public Rol Rol { get; set; } = null!;

        [ForeignKey("PermisoId")]
        public virtual Permiso Permiso { get; set; } = null!;
    }
}
