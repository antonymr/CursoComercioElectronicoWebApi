using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.ComercioElectronico.Infraestructura.EntityConfigurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductTypes");
            builder.HasKey(b => b.Code);

            builder.Property(b => b.Code)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(b => b.Name)
                .HasMaxLength(256)
                .IsRequired();
            
            builder.Property(b => b.Description)
                .HasMaxLength(256);
        }
    }
}
