using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Contrato.entities;
using Contrato.servicios.cliente;
using Servicio;
using Contrato.servicios.cliente.solicitudes;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IServicioCliente _servicioCliente;
        public ClienteController(IServicioCliente servicioCliente)
        {
            _servicioCliente = servicioCliente;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SolicitudObtener solicitud)
        {
            try
            {
                var clientes = await _servicioCliente.Obtener(solicitud);
                return Ok(clientes.Clientes);
            }
            catch (Exception exeeee) {

                exeeee.ToString();
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SolicitudCrear solicitud)
        {
            try
            {
                var respuesta_crear = await _servicioCliente.Crear(solicitud);
                return Ok(respuesta_crear);
            }

            catch (Exception exee2) {
                exee2.ToString();
                return null;
            }
        }
    }
}
