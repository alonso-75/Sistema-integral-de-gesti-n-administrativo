namespace SistemaAdministrativoAPI.Models.Usuario.DTOS
{
    public class RolDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public List<long>? Permisos { get; set; }
    }
}
