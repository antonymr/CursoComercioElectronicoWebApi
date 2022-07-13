using Curso.ComercioElectronico.Dominio;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Infraestructura
{
    public class ComercioElectronicoDbContext : DbContext
    {
        public ComercioElectronicoDbContext(DbContextOptions options):base(options){}

        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Brand> Brands{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        //    // 1. Configurar provedor
        //    // 2. Configurar conexxion
        //    //var conexion = @"Server=(localdb)\mssqllocaldb;Database=ComercioElectronico;Trusted_Connection=True";
        //    //optionsBuilder.UseSqlServer(conexion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>(p =>
            //{
            //    p.ToTable("Products");
            //    p.HasKey(b => b.Id);


            //    //ID
            //    p.Property(b => b.Id)
            //    .IsRequired();

            //    //Campos normales
            //    p.Property(b => b.Name)
            //    .HasMaxLength(100)
            //    .IsRequired();
            //});
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
