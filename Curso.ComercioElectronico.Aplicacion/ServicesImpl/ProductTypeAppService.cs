using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class ProductTypeAppService : IProductTypeAppService
    {
        private readonly IGenericRepository<ProductType> productTypeRepository;
        private readonly IValidator<CreateProductTypeDto> validator;

        public ProductTypeAppService(IGenericRepository<ProductType> repository, IValidator<CreateProductTypeDto> validator)
        {
            productTypeRepository = repository;
            this.validator = validator;
        }

        public async Task<ICollection<ProductTypeDto>> GetAllAsync()
        {
            var query = await productTypeRepository.GetAsync();
            var result = query.Select(x => new ProductTypeDto
            {
                Code = x.Code,
                Description = x.Description,
                CreationDate = x.CreationDate
            });
            return result.ToList();
        }

        public async Task<ProductTypeDto> GetByIdAsync(string id)
        {
            var entity = await productTypeRepository.GetByIdAsync(id);
            return new ProductTypeDto { Code = entity.Code, Description = entity.Description, CreationDate = entity.CreationDate };
        }

        public async Task<bool> DeleteAsync(ProductType entity)
        {
            await productTypeRepository.DeleteAsync(entity);
            return true;
        }
        public async Task<ProductTypeDto> UpdateAsync(ProductType entity)
        {
            await productTypeRepository.UpdateAsync(entity);
            return await GetByIdAsync(entity.Code);
        }
        public async Task CreateAsync(CreateProductTypeDto productTypeDto)
        {
            var productType = new ProductType
            {
                Code = productTypeDto.Code,
                Description = productTypeDto.Description
            };
            await productTypeRepository.CreateAsync(productType);
        }
    }
}
