using System.ComponentModel.DataAnnotations;

namespace Contrato.servicios.cliente.solicitudes
{
    public class SolicitudCrear
    {
        [Required]
        [MinLength(4)]
        public string Nombre { get; set; }
        [Required]
        [MinLength(4)]
        public string Reino { get; set; }
    }
}
