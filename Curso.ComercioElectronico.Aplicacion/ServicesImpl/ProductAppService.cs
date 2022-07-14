using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class ProductAppService : IProductAppService
    {
        private readonly IGenericRepository<Product> productRepository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateProductDto> productDtoValidator; 

        public ProductAppService(IGenericRepository<Product> repository, IMapper mapper, IValidator<CreateProductDto> productDtoValidator)
        {
            productRepository = repository;
            this.mapper = mapper;
            this.productDtoValidator = productDtoValidator;
        }

        public async Task<ResultPagination<ProductDto>> GetAllAsync(string? search = "", int offset = 0, int limit = 10, string sort = "Name", string order = "asc")
        {
            var query = productRepository.GetQueryable();

            //filtro de eleminados
            query = query.Where(p => p.IsDeleted == false);

            // Busqueda
            if (!string.IsNullOrEmpty(search))
            {
                //filtro
                query = query.Where(
                    x => x.Name.ToUpper().Contains(search.ToUpper())
                );

            }
            
            //Total
            var total = await query.CountAsync();

            //Ordenamiento
            if (!string.IsNullOrEmpty(sort))
            {
                //Ordenar por nombre o precio
                switch (sort.ToUpper())
                {
                    case "NAME":
                        query = query.OrderBy(x => x.Name);
                        break;
                    case "PRICE":
                        query = query.OrderBy(x => x.Price);
                        break;
                    default:
                        throw new ArgumentException($"The parameter sort {sort} not support");
                }
            }

            //Paginacion
            query = query.Skip(offset).Take(limit);

            //items
            var queryDto = query.Select(p => new ProductDto { 
                Id = p.Id, 
                Name = p.Name, 
                Description = p.Description, 
                Price = p.Price, 
                Brand = p.Brand.Description, 
                ProductType = p.ProductType.Description 
            });
            var items = await queryDto.ToListAsync();

            var result = new ResultPagination<ProductDto>();
            result.Total = total;
            result.Items = items;

            return result;
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var query = productRepository.GetQueryable();
            query = query.Where(p => p.Id == id);
            var resultQuery = query.Select(p => new ProductDto { 
                Id = p.Id, 
                Name = p.Name, 
                Description = p.Description, 
                Price = p.Price, 
                Brand = p.Brand.Description, 
                ProductType = p.ProductType.Description 
            });
            return await resultQuery.SingleOrDefaultAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            product.IsDeleted = true;
            product.ModifiedDate = DateTime.Now;
            await productRepository.DeleteAsync(product);
        }

        public async Task UpdateAsync(Guid id, CreateProductDto productDto)
        {
            var product = await productRepository.GetByIdAsync(id);
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.ModifiedDate = DateTime.Now;
            product.BrandId = productDto.BrandId;
            product.ProductTypeId = productDto.ProductTypeId;
            await productRepository.UpdateAsync(product);
        }

        public async Task CreateAsync(CreateProductDto productDto)
        {
            var validation = productDtoValidator.Validate(productDto);
            if (!validation.IsValid)
            {
                throw new FormatException(validation.ToString());
            }
            var product = mapper.Map<Product>(productDto);
            product.Id = Guid.NewGuid();
            product.CreationDate = DateTime.Now;
            await productRepository.CreateAsync(product);
        }
    }
}
