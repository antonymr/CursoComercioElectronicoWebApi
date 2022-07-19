
namespace Curso.ComercioElectronico.Aplicacion.Dtos.Create
{
    public class CreateOrderDto
    {
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }

        public string DeliveryMethodId { get; set; }
        public List<CreateOrderLinetDto> OrderLines { get; set; }
    }
}
