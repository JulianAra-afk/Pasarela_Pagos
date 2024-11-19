using Microsoft.AspNetCore.Mvc;
using Pasarela.Entity;
using Pasarela.Service;

namespace Pasarela.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasarelaController : ControllerBase
    {
        private readonly PasarelaService _pagoService;

        public PasarelaController(PasarelaService pagoService)
        {
            _pagoService = pagoService ?? throw new ArgumentNullException(nameof(pagoService));
        }

        // Acción para obtener todos los pagos
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                var pagos = _pagoService.ObtenerTodos();
                if (pagos == null || pagos.Count == 0)
                    return NotFound("No se encontraron pagos.");

                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los pagos: {ex.Message}");
            }
        }

        // Acción para obtener un pago por su ID
        [HttpGet("{id}")]
        public IActionResult ObtenerPagoPorId(int id)
        {
            try
            {
                var pago = _pagoService.ObtenerPagoPorId(id);
                if (pago == null)
                    return NotFound($"No se encontró el pago con ID {id}");

                return Ok(pago);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el pago: {ex.Message}");
            }
        }

        // Acción para crear un nuevo pago
        [HttpPost("crear")]
        public IActionResult CrearPago([FromBody] Pago pago)
        {
            try
            {
                var resultado = _pagoService.CrearPago(pago);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el pago: {ex.Message}");
            }
        }

        // Acción para actualizar un pago existente
        [HttpPut("actualizar/{id}")]
        public IActionResult ActualizarPago(int id, [FromBody] Pago pagoActualizado)
        {
            try
            {
                var resultado = _pagoService.ActualizarPago(id, pagoActualizado);
                if (resultado == "Pago no encontrado.")
                    return NotFound(resultado);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el pago: {ex.Message}");
            }
        }

        // Acción para eliminar un pago por ID
        [HttpDelete("eliminar/{id}")]
        public IActionResult EliminarPago(int id)
        {
            try
            {
                var resultado = _pagoService.EliminarPago(id);
                if (resultado == "Pago no encontrado.")
                    return NotFound(resultado);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el pago: {ex.Message}");
            }
        }

        // Acción para procesar un pago usando el ID de una factura
        [HttpPost("procesar/{facturaId}")]
        public IActionResult ProcesarPagoPorFactura(int facturaId)
        {
            try
            {
                var pago = _pagoService.ObtenerPagoPorId(facturaId);
                if (pago == null)
                    return NotFound($"No se encontró el pago asociado con la factura ID {facturaId}");

                var resultado = _pagoService.ProcesarPago(pago);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error procesando el pago: {ex.Message}");
            }
        }
    }
}