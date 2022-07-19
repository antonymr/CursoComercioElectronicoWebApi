using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.ComercioElectronico.Infraestructura.EntityConfigurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .IsRequired();

            builder.Property(b => b.ClientName)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(b => b.ClientAddress)
                .HasMaxLength(256);

            builder.Property(b => b.Subtotal)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            
            builder.Property(b => b.Taxes)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            
            builder.Property(b => b.Discount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.Total)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            //DeliveryMethod
            builder.HasOne(b => b.DeliveryMethod)
                .WithMany()
                .HasForeignKey(b => b.DeliveryMethodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
