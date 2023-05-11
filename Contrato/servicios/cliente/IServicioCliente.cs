namespace Contrato.servicios.cliente
{
    public interface IServicioCliente
    {
        Task<respuestas.RespuestaObtener> Obtener(solicitudes.SolicitudObtener solicitudes);
        Task<respuestas.RespuestaCrear> Crear(solicitudes.SolicitudCrear solicitud);
    }
}
