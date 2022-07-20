using Curso.ComercioElectronico.Dominio.Entities.Base;

namespace Curso.ComercioElectronico.Dominio.Entities
{
    public class Order : BaseBusinessEntity
    {
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Taxes { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }

        public string DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
    }
}
