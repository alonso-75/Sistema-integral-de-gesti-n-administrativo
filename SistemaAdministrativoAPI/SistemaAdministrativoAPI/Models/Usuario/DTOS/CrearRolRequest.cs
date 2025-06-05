namespace SistemaAdministrativoAPI.Models.Usuario.DTOS
{
    public class CrearRolRequest
    {
        public string Nombre { get; set; }
        public List<long> PermisosId { get; set; }
    }
}
