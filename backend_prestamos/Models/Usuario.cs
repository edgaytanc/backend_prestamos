using System;
namespace backend_prestamos.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdProveedor { get; set; }
        public string Contrasena { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;

        //public Proveedor Proveedor { get; set; }

        
    }
}
