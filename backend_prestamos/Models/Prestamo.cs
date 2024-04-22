using System;
namespace backend_prestamos.Models
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public int IdProveedor { get; set; }
        public decimal Monto { get; set; }
        public decimal TasaInteres {  get; set; }
        public int Plazo { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaDesembolso { get; set; }
        public string Estado { get; set; }

        //public Proveedor Proveedor { get; set; }
    }
}
