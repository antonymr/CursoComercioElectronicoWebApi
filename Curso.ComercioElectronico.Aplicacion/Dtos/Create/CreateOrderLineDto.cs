
namespace Curso.ComercioElectronico.Aplicacion.Dtos.Create
{
    public class CreateOrderLineDto
    {
        public int Quantity { get; set; }
        public decimal TaxRate { get; set; }
        public decimal DiscountRate { get; set; } = 0;
        public Guid ProductId { get; set; }
    }
}
