﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Descrription { get; set; }
        public decimal Price { get; set; }
        public string ProductTypeId { get; set; }
        public string BrandId { get; set; }
    }
}
