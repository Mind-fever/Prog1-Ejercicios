using BibliotecaDeClases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GestionRequerimientos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuscripcionController : Controller
    {
        private Principal administrador;
        public SuscripcionController()
        {
            administrador = new Principal();         

        }
        [HttpPost("")]
        public IActionResult CrearNuevaSucripcion([FromBody] Suscripcion nuevaSuscripcion)
        {
            var susNueva = administrador.CrearSuscripcion(nuevaSuscripcion);

            if (susNueva.Codigo == 0)
            {
                return BadRequest("Error en crear suscripcion");
            }

            return Ok(susNueva);
        }
        [HttpGet("{id}")]
        public IActionResult ObtenerDetalleSuscripcion(int id)
        {
            var suscripcion = administrador.ObtenerSuscripcion(id);
            if (suscripcion == null)
            {
                return NotFound($"Suscripcion con ID {id} no encontrada.");
            }
            return Ok(suscripcion);
        }
        [HttpPut("{id}")]
        public IActionResult ActualizarMontoSuscripcion([FromBody] Suscripcion susModificada, int id)
        {
            var actualizarMontoResponse = administrador.ActualizarMonto(susModificada, id);

            if (actualizarMontoResponse.Accionar == true)
            {
                return Ok(actualizarMontoResponse);
            }

            return BadRequest(actualizarMontoResponse);
        }
        [HttpDelete("{id}")]
        public IActionResult EliminarSuscripcion(int id)
        {
            var resul = administrador.EliminarSuscripcion(id);

            if (resul.Accionar)
            {
                return Ok(resul);
            }
            return NotFound(resul);
        }
        [HttpGet()]
        public IActionResult ObtenerListaOrdenada(int fecha_monto, int orden)
        {
            List<Suscripcion> suscripciones = administrador.ObtenerSuscripciones(fecha_monto, orden);
            return Ok(suscripciones);
        }
    }
}