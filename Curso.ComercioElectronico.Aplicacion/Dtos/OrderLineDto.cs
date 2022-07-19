
namespace Curso.ComercioElectronico.Aplicacion.Dtos
{
    public class OrderLineDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Taxes { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }

        public string Product { get; set; }
        public string Order { get; set; }
    }
}
