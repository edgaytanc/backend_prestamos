using System.Collections.Generic;
namespace backend_prestamos.Models
{
    public class Proveedor
    {
        public int IdProveedor {  get; set; }
        public int IdDocumento { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Nit { get; set; } = string.Empty;

        //public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        //public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        //public ICollection<Usuario> Usuarios { get; set; }
        //public ICollection<Prestamo> Prestamos { get; set; }
    }
}
