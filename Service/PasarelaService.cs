using Pasarela.Entity;

namespace Pasarela.Service
{
    public class PasarelaService
    {
        private readonly List<Pago> _pagos;

        // Constructor para inicializar la lista de pagos (simulación de base de datos)
        public PasarelaService()
        {
            _pagos = new List<Pago>();
        }

        // Obtener todos los pagos
        public List<Pago> ObtenerTodos()
        {
            return _pagos;  // En una implementación real, esto vendría de la base de datos.
        }

        // Obtener un pago por ID de factura
        public Pago ObtenerPagoPorId(int pagoId)
        {
            return _pagos.FirstOrDefault(p => p.PagoId == pagoId);  // Buscar por ID
        }

        // Crear un nuevo pago
        public string CrearPago(Pago pago)
        {
            // Simulamos la creación (en una base de datos real sería un insert)
            _pagos.Add(pago);
            return $"Pago con ID {pago.PagoId} creado con éxito.";
        }

        // Actualizar un pago existente
        public string ActualizarPago(int pagoId, Pago pagoActualizado)
        {
            var pagoExistente = _pagos.FirstOrDefault(p => p.PagoId == pagoId);
            if (pagoExistente == null)
                return "Pago no encontrado.";

            // Actualizar las propiedades del pago
            pagoExistente.UsuarioId = pagoActualizado.UsuarioId;
            pagoExistente.TransaccionId = pagoActualizado.TransaccionId;
            pagoExistente.Tipo = pagoActualizado.Tipo;
            pagoExistente.Monto = pagoActualizado.Monto;
            pagoExistente.Metodo_Pago = pagoActualizado.Metodo_Pago;
            pagoExistente.Estado_Pago = pagoActualizado.Estado_Pago;
            pagoExistente.Fecha_Pago = pagoActualizado.Fecha_Pago;

            return $"Pago con ID {pagoId} actualizado con éxito.";
        }

        // Eliminar un pago por ID
        public string EliminarPago(int pagoId)
        {
            var pago = _pagos.FirstOrDefault(p => p.PagoId == pagoId);
            if (pago == null)
                return "Pago no encontrado.";

            _pagos.Remove(pago);
            return $"Pago con ID {pagoId} eliminado con éxito.";
        }

        // Procesar el pago (simulación de procesamiento)
        public string ProcesarPago(Pago pago)
        {
            pago.Estado_Pago = Estadopago.Completado;  // Cambiar el estado a completado
            return $"Pago de {pago.Monto} procesado con éxito. Estado: {pago.Estado_Pago}";
        }
    }
}