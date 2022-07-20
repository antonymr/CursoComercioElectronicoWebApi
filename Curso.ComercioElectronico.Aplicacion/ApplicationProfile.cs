using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using Curso.ComercioElectronico.Dominio.Entities;

namespace Curso.ComercioElectronico.Aplicacion
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<CreateProductTypeDto, ProductType>();
            CreateMap<CreateDeliveryMethodDto, DeliveryMethod>();

            CreateMap<Product, ProductDto>();
            CreateMap<Brand, BrandDto>();
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<DeliveryMethod,DeliveryMethodDto>();
        }
    }
}
