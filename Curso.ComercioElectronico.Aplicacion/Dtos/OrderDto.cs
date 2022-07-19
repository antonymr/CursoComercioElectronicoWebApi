
namespace Curso.ComercioElectronico.Aplicacion.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Taxes { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }

        public string DeliveryMethodId { get; set; }
        public List<OrderLineDto> OrderLines { get; set; }
    }
}
