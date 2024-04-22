using System;
namespace backend_prestamos.Models
{
    public class Documento
    {
        public int IdDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Encabezado { get; set; }
        public string Detalle {  get; set; } // Podria requerir ajuste debido a CLOB 
        public string NumeroDocumento { get; set; }
        public string NumeroSerie { get; set; }
        public decimal Cantidad { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
    }
}
