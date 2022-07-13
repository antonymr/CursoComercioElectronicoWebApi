using Curso.ComercioElectronico.Dominio.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Dominio.Entities
{
    public class Product : BaseBusinessEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Size Size { get; set; }
        //Relaciones
        public ProductType ProductType { get; set; }
        public string ProductTypeId { get; set; }
        public Brand Brand { get; set; }
        public string BrandId { get; set; }

    }

    public enum Size
    {
        [Display(Name = "Grande")]
        Large = 2,
        [Display(Name = "Mediano")]
        Medium = 1,
        [Display(Name = "Pequenio")]
        Small = 0,
    }
}
