using SistemaAdministrativoAPI.Models.Gestion_de_Pqrsd;

namespace SistemaAdministrativoAPI.Servicios
{
    public interface IPqrsdService
    {
        Task<List<Pqrsd>> GetAllAsync();
        Task<Pqrsd?> GetByIdAsync(long id);
        Task<Pqrsd> CreateAsync(Pqrsd pqrsd);
        Task<Pqrsd?> UpdateAsync(long id, Pqrsd updated);
        Task<bool> DeleteAsync(long id);
        Task<Pqrsd> CreateWithArchivosAsync(PqrsdDto dto);
    }
}
