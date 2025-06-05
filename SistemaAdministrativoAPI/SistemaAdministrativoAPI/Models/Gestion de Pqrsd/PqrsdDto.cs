using SistemaAdministrativoAPI.Models.Archivos;

namespace SistemaAdministrativoAPI.Models.Gestion_de_Pqrsd
{
    public class PqrsdDto
    {
        public string Radicado { get; set; } = string.Empty;
        public DateTime FechaRecibido { get; set; }
        public string Remitente { get; set; } = string.Empty;
        public string Asunto { get; set; } = string.Empty;
        public int Folios { get; set; }
        public string Razon { get; set; } = string.Empty;
        public string RecibidoPor { get; set; } = string.Empty;
        public string Responsable { get; set; } = string.Empty;
        public DateTime? FechaEntregaResponsable { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int? DiasFaltantes { get; set; }
        public string? Cumplimiento { get; set; }
        public string? Rp { get; set; }
        public string? Observaciones { get; set; }
        public List<ArchivoDto> Archivos { get; set; } = new();
    }
}
