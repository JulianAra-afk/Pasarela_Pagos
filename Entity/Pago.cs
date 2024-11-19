namespace Pasarela.Entity{
   public class Pago
   {
      public int PagoId { get; set; }
      public int UsuarioId { get; set; }
      public int TransaccionId { get; set; }
      public string? Tipo { get; set; }
      public decimal Monto { get; set; }
      public Metodopago Metodo_Pago { get; set; }
      public Estadopago Estado_Pago { get; set; }
      public DateTime Fecha_Pago { get; set; }
   }

   public enum Metodopago
   {
      Efecty, PayPal, Tarjeta, Banco
   }
   public enum Estadopago
   {
      Completado, Tramitando, Rechazado
   }

}