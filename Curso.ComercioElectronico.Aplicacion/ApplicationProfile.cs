using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //<Origen, Destino>
            CreateMap<CreateProductDto, Product>();
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<CreateProductTypeDto, ProductType>();
        }
    }
}
