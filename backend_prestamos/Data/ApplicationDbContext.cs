using Microsoft.EntityFrameworkCore;
using backend_prestamos.Models;

namespace backend_prestamos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set;}
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<MetodoDePago> MetodosDePagos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Contrasena> Contrasenas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Configuraricon de nombres de tablas y claves primarias
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");
                entity.HasKey(e => e.IdUsuario);
                entity.Property(u => u.IdUsuario).HasColumnName("ID_USUARIO"); // Asegurándose de que el nombre de columna sea correcto
                entity.Property(u => u.IdProveedor).HasColumnName("ID_PROVEEDOR"); // Asegurándose de que el nombre de columna sea correcto
                entity.Property(u => u.Contrasena).HasColumnName("CONTRASENA"); // Asegurándose de que el nombre de columna sea correcto
                entity.Property(u => u.NombreUsuario).HasColumnName("NOMBRE_USUARIO").HasMaxLength(100); // Asegurandose de que el nombre de la columna y su tamano sea correcto

                //Especifica la relacion y clave roranea correctamente
                //entity.HasOne(u => u.Proveedor) //Propiedad de navegacion en Usuario
                //.WithMany(p => p.Usuarios)      //Propiedad de navegacion en Proveedor
                //.HasForeignKey(u => u.IdProveedor);// clave foranea de Usuario que apunta a Proveedor
            });



            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("PROVEEDOR");
                entity.HasKey(e => e.IdProveedor);
                entity.Property(p => p.Nombre).HasColumnName("NOMBRE");
                entity.Property(p => p.Nit).HasColumnName("NIT");
                entity.Property(p => p.Direccion).HasColumnName("DIRECCION");
                entity.Property(p => p.Email).HasColumnName("EMAIL");
                entity.Property(p => p.IdProveedor).HasColumnName("ID_PROVEEDOR");
                entity.Property(p => p.IdDocumento).HasColumnName("ID_DOCUMENTO");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.ToTable("PRESTAMOS");
                entity.HasKey(e => e.IdPrestamo);
                entity.Property(p => p.IdPrestamo).HasColumnName("ID_PRESTAMO");
                entity.Property(p => p.IdProveedor).HasColumnName("ID_PROVEEDOR");
                entity.Property(p => p.Monto).HasColumnName("MONTO").HasPrecision(18, 2);
                entity.Property(p => p.TasaInteres).HasColumnName("TASA_INTERES").HasPrecision(15, 2);
                entity.Property(p => p.Plazo).HasColumnName("PLAZO");
                entity.Property(p => p.FechaSolicitud).HasColumnName("FECHA_SOLICITUD");
                entity.Property(p => p.FechaDesembolso).HasColumnName("FECHA_DESEMBOLSO");
                entity.Property(p => p.Estado).HasColumnName("ESTADO");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.ToTable("DOCUMENTOS");
                entity.HasKey(e => e.IdDocumento);
                entity.Property(p => p.IdDocumento).HasColumnName("ID_DOCUMENTO");
                entity.Property(p => p.TipoDocumento).HasColumnName("TIPO_DOCUMENTO");
                entity.Property(p => p.Encabezado).HasColumnName("ENCABEZADO");
                entity.Property(p => p.Detalle).HasColumnName("DETALLE");
                entity.Property(p => p.NumeroDocumento).HasColumnName("NUMERO_DOCUMENTO");
                entity.Property(p => p.NumeroSerie).HasColumnName("NUMERO_SERIE");
                entity.Property(p => p.Cantidad).HasColumnName("CANTIDAD").HasPrecision(18,2);
                entity.Property(p => p.Moneda).HasColumnName("MONEDA");
                entity.Property(p => p.Estado).HasColumnName("ESTADO");
            });

            modelBuilder.Entity<Contrasena>(entity =>
            {
                entity.ToTable("CONTRASENA");
                entity.HasKey(e => e.IdContrasena);
                entity.Property(p => p.IdContrasena).HasColumnName("ID_CONTRASENA");
                entity.Property(p => p.IdPago).HasColumnName("ID_PAGO");
                entity.Property(p => p.IdProveedor).HasColumnName("ID_PROVEEDOR");
                entity.Property(p => p.DatosDeFactura).HasColumnName("DATOS_DE_FACTURA");
                entity.Property(p => p.Nombre).HasColumnName("NOMBRE");
                entity.Property(p => p.Moneda).HasColumnName("MONEDA");
                entity.Property(p => p.CanalDePago).HasColumnName("CANAL_DE_PAGO");
                entity.Property(p => p.Fecha).HasColumnName("FECHA");
                entity.Property(p => p.Hora).HasColumnName("HORA");
                entity.Property(p => p.FechaDeVencimiento).HasColumnName("FECHA_DE_VENCIMIENTO");
                entity.Property(p => p.Retencion).HasColumnName("RETENCION").HasPrecision(18,2);
                entity.Property(p => p.Direccion).HasColumnName("DIRECCION");
                entity.Property(p => p.TotalAPagar).HasColumnName("TOTAL_A_PAGAR").HasPrecision(18,2);

                
            });

            modelBuilder.Entity<MetodoDePago>(entity =>
            {
                entity.ToTable("METODO_DE_PAGO");
                entity.HasKey(e => e.IdPago);
                entity.Property(p => p.IdPago).HasColumnName("ID_PAGO");
                entity.Property(p => p.IdMetodoPago).HasColumnName("ID_METODO_DE_PAGO");
                entity.Property(p => p.IdContrasena).HasColumnName("ID_CONTRASENA");
            });

            

            

            // mas configuraciones de otras entidades
        }
    }
}
