
namespace Curso.ComercioElectronico.Aplicacion.Dtos.Create
{
    public class CreateOrderLinetDto
    {
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Taxes { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public Guid ProductId { get; set; }
    }
}
