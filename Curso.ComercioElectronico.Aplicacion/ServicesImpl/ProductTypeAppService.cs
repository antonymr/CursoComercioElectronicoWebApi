using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using Curso.ComercioElectronico.Aplicacion.Exceptions;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using FluentValidation;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class ProductTypeAppService : IProductTypeAppService
    {
        private readonly IGenericRepository<ProductType> productTypeRepository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateProductTypeDto> validator;

        public ProductTypeAppService(IGenericRepository<ProductType> repository, IMapper mapper, IValidator<CreateProductTypeDto> validator)
        {
            productTypeRepository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<ICollection<ProductTypeDto>> GetAllAsync()
        {
            var query = await productTypeRepository.GetAsync();
            var result = query.Where(x => x.IsDeleted == false).Select(x =>  mapper.Map<ProductTypeDto>(x));
            return result.ToList();
        }

        public async Task<ProductTypeDto> GetByIdAsync(string code)
        {
            var productType = await productTypeRepository.GetByIdAsync(code);
            if (productType == null || productType.IsDeleted == true)
                throw new NotFoundException($"Tipo de Producto con codigo {code} no encontrado");
            var productTypeDto = mapper.Map<ProductTypeDto>(productType);
            return productTypeDto;
        }

        public async Task DeleteAsync(string code)
        {
            var productType = await productTypeRepository.GetByIdAsync(code);
            if (productType == null || productType.IsDeleted == true)
                throw new NotFoundException($"Tipo de Producto con codigo {code} no encontrado");
            productType.IsDeleted = true;
            productType.ModifiedDate = DateTime.Now;
            await productTypeRepository.UpdateAsync(productType);
        }

        public async Task UpdateAsync(string code, CreateProductTypeDto productTypeDto)
        {
            await validator.ValidateAndThrowAsync(productTypeDto);
            var productType = await productTypeRepository.GetByIdAsync(code);
            if (productType == null || productType.IsDeleted == true)
                throw new NotFoundException($"Tipo de Producto con codigo {code} no encontrado");
            productType.Code = productTypeDto.Code;
            productType.Name = productTypeDto.Name;
            productType.Description = productTypeDto.Description;
            productType.ModifiedDate = DateTime.Now;
            await productTypeRepository.UpdateAsync(productType);
        }

        public async Task CreateAsync(CreateProductTypeDto productTypeDto)
        {
            await validator.ValidateAndThrowAsync(productTypeDto);
            var exists = await productTypeRepository.GetByIdAsync(productTypeDto.Code);
            if (exists != null)
                throw new BusinessException($"Tipo de Producto con codigo {productTypeDto.Code} ya existe.");
            var productType = mapper.Map<ProductType>(productTypeDto);
            productType.CreationDate = DateTime.Now;
            await productTypeRepository.CreateAsync(productType);
        }
    }
}
