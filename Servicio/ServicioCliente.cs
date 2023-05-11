using Contrato.entities;
using Contrato.servicios.cliente;
using Contrato.servicios.cliente.respuestas;
using Contrato.servicios.cliente.solicitudes;
using Dominio.Infraestructura;
using System.Linq.Expressions;

namespace Servicio
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly IRepositorio<Dominio.entities.Cliente> _repositorioCliente;
  

        public ServicioCliente(IRepositorio<Dominio.entities.Cliente> repositorioCliente)
        {
            this._repositorioCliente = repositorioCliente;
        }


        public async Task<RespuestaObtener> Obtener(SolicitudObtener solicitud)
        {
            var respuesta = new RespuestaObtener();
            var predicado = ArmarPredicado(solicitud);
            var respuesta_servicio = await _repositorioCliente.Buscar(predicado);
            respuesta.Clientes = respuesta_servicio.Select(c => new Cliente()
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Reino = c.Reino
            }).ToList();
            return respuesta;
        }

        private Expression<Func<Dominio.entities.Cliente, bool>> ArmarPredicado(SolicitudObtener solicitud)
        {
            var predicado = CrearPredicado.Verdadero<Dominio.entities.Cliente>();
            if (!string.IsNullOrEmpty(solicitud.Reino)) predicado = predicado.Y(c => c.Reino.ToLower().Contains(solicitud.Reino.ToLower()));
            if (solicitud.Id > 0) predicado = predicado.Y(c => c.Id == solicitud.Id);
            if (!string.IsNullOrEmpty(solicitud.Nombre)) predicado = predicado.Y(c => c.Nombre.ToLower().Contains(solicitud.Nombre.ToLower()));
            return predicado;
        }

        private Dominio.entities.Cliente MapearCliente(SolicitudCrear solicitud)
        {
            var cliente = new Dominio.entities.Cliente();
            cliente.Nombre = solicitud.Nombre;
            cliente.Reino = solicitud.Reino;
            cliente.FechaAlta = DateTime.Now;
            return cliente;
        }

        public async Task<RespuestaCrear> Crear(SolicitudCrear solicitud)
        {
            var respuesta = new RespuestaCrear();
            var nuevo_cliente = MapearCliente(solicitud);
            await _repositorioCliente.Crear(nuevo_cliente);
            respuesta.Id = nuevo_cliente.Id;
            return respuesta;
        }

    }
}
