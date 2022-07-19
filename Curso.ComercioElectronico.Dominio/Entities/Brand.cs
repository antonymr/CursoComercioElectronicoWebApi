using Curso.ComercioElectronico.Dominio.Entities.Base;

namespace Curso.ComercioElectronico.Dominio.Entities
{
    public class Brand : BaseCatalogEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
