using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.ComercioElectronico.Infraestructura.EntityConfigurations
{
    internal class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.ToTable("OrderLines");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .IsRequired();

            builder.Property(b => b.Quantity)
                .IsRequired();

            builder.Property(b => b.Subtotal)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.Taxes)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.TaxRate)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.Discount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.DiscountRate)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.Total)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            //Order
            builder.HasOne(b => b.Order)
                .WithMany()
                .HasForeignKey(b => b.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            //Product
            builder.HasOne(b => b.Product)
                .WithMany()
                .HasForeignKey(b => b.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
