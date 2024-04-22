using System;
namespace backend_prestamos.Models
{
    public class Contrasena
    {
        public int IdContrasena {  get; set; }
        public int IdPago { get; set; }
        public int IdProveedor { get; set; }
        public string DatosDeFactura { get; set; } // Podria requerir ajuste debido al CLOB
        public string Nombre { get; set; }
        public string Moneda { get; set; }
        public string CanalDePago { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public DateTime FechaDeVencimiento { get; set; }
        public decimal Retencion { get; set; }
        public string Direccion { get; set; }
        public decimal TotalAPagar { get; set; }

        
    }
}
