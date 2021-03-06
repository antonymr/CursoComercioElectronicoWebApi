
namespace Curso.ComercioElectronico.Aplicacion.Dtos
{
    public class DeliveryMethodDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool needAddress { get; set; } = false;
        public DateTime CreationDate { get; set; }
    }
}
