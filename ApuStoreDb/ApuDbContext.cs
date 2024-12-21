using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApuStoreDb.Models;

namespace ApuStoreDb
{
    public class ApuDbContext : DbContext
    {
        private readonly string? _connectionString; // =  @"Data Source=.\SQLExpress;Initial Catalog=BDBcnDietario;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        /// <summary>
        /// constructor para la inyección de dependencias
        /// </summary>
        /// <param name="options"></param>
        public ApuDbContext(DbContextOptions<ApuDbContext> options) : base(options) { }


        /// <summary>
        /// constructor por defecto para que funcionen los generadores de código
        /// </summary>
        public ApuDbContext() => _connectionString = "";

        /// <summary>
        /// constructor para pasar la cadena de conexión en un uso directo
        /// </summary>
        /// <param name="connectionString"></param>
        public ApuDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (!string.IsNullOrEmpty(_connectionString))
                {
                    optionsBuilder.UseSqlServer(_connectionString);
                }
            }

            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IniciosSesion>().HasQueryFilter(e => !e.Borrado);
            modelBuilder.Entity<Roles>().HasQueryFilter(e => !e.Borrado);
            modelBuilder.Entity<Productos>().HasQueryFilter(e => !e.Borrado && e.Estado == 1);
            modelBuilder.Entity<ProductosTipo>().HasQueryFilter(e => !e.Borrado);
            modelBuilder.Entity<ProductosTallas>().HasQueryFilter(e => !e.Borrado);
            modelBuilder.Entity<ProductosColores>().HasQueryFilter(e => !e.Borrado);
            modelBuilder.Entity<ProductosFotos>().HasQueryFilter(e => !e.Borrado);            


            modelBuilder.Entity<ProductosTipo>()
                .HasOne(t => t.GrabadoPor)
                .WithMany(g => g.Registrador)
                .HasForeignKey(t => t.RegistroSesionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductosTipo>()
                .HasOne(t => t.EditadoPor)
                .WithMany(e  => e.Editor)
                .HasForeignKey(t => t.EdicionSesionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Productos>()
                .HasOne(t => t.Tipo)
                .WithMany(p => p.Productos)
                .HasForeignKey(p => p.TipoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Productos>()
                .HasOne(pt => pt.Talla)
                .WithMany(p => p.Productos)
                .HasForeignKey(p => p.TallaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Productos>()
               .HasOne(pt => pt.Marca)
               .WithMany(p => p.Productos)
               .HasForeignKey(p => p.MarcaId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Productos>()
               .HasOne(pt => pt.Color)
               .WithMany(p => p.Productos)
               .HasForeignKey(p => p.ColorId)
               .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Productos>()
            //    .HasOne(f => f.Foto)
            //    .WithMany(p => p.Productos)
            //    .HasForeignKey(p => p.Id)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Productos>()
              .HasMany(f => f.Fotos)
              .WithOne(p => p.Producto)
              .HasForeignKey(p => p.IdProducto)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductosFotos>()
             .HasOne(f => f.Producto)
             .WithMany(p => p.Fotos)
             .HasForeignKey(p => p.IdProducto)
             .OnDelete(DeleteBehavior.Restrict);


        }

        public DbSet<IniciosSesion> IniciosSesion { get; set; }
        public DbSet<Roles> Roles { get; set; }       
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProductosColores> ProductosColores { get; set; }
        public DbSet<ProductosEspecificaciones> ProductosEspecificaciones { get; set; }
        public DbSet<ProductosFotos> ProductosFotos { get; set; }
        public DbSet<ProductosMarcas> ProductosMarcas { get; set; }
        public DbSet<ProductosStocks> ProductosStocks { get; set; }
        public DbSet<ProductosTallas> ProductosTallas { get; set; }
        public DbSet<ProductosTipo> ProductosTipo { get; set; }
        public DbSet<ProductosTransacciones> ProductosTransacciones { get; set; }
        public DbSet<TransaccionCuotas> TransaccionCuotas { get; set; }
        public DbSet<TransaccionesFormaspago> TransaccionesFormaspago { get; set; }
        public object Producto { get; set; }
    }
}
