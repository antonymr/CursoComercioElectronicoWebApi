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
    public class BrandAppService : IBrandAppService
    {
        private readonly IGenericRepository<Brand> brandRepository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateBrandDto> validator;

        public BrandAppService(IGenericRepository<Brand> repository, IMapper mapper, IValidator<CreateBrandDto> validator)
        {
            brandRepository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<ICollection<BrandDto>> GetAllAsync()
        {
            var query = await brandRepository.GetAsync();
            var result = query.Where(x => x.IsDeleted == false).Select(x => mapper.Map<BrandDto>(x));
            return result.ToList();
        }

        public async Task<BrandDto> GetByIdAsync(string code)
        {
            var brand = await brandRepository.GetByIdAsync(code);
            if (brand == null || brand.IsDeleted == true)
                throw new NotFoundException($"Marca con codigo {code} no encontrado.");
            var brandDto = mapper.Map<BrandDto>(brand);
            return brandDto;
        }

        public async Task DeleteAsync(string code)
        {
            var brand = await brandRepository.GetByIdAsync(code);
            if (brand == null || brand.IsDeleted == true)
                throw new NotFoundException($"Marca con codigo {code} no encontrado.");
            brand.IsDeleted = true;
            brand.ModifiedDate = DateTime.Now;
            await brandRepository.UpdateAsync(brand);
        }

        public async Task UpdateAsync(string code, CreateBrandDto brandDto)
        {
            await validator.ValidateAndThrowAsync(brandDto);
            var brand = await brandRepository.GetByIdAsync(code);
            if (brand == null || brand.IsDeleted == true)
                throw new NotFoundException($"Marca con codigo {code} no encontrado.");
            brand.Code = brandDto.Code;
            brand.Name = brandDto.Name;
            brand.Description = brandDto.Description;
            brand.ModifiedDate = DateTime.Now;
            await brandRepository.UpdateAsync(brand);
        }

        public async Task CreateAsync(CreateBrandDto brandDto)
        {
            await validator.ValidateAndThrowAsync(brandDto);
            var exists = await brandRepository.GetByIdAsync(brandDto.Code);
            if (exists != null)
                throw new BusinessException($"Marca con codigo {brandDto.Code} ya existe.");
            var brand = mapper.Map<Brand>(brandDto);
            brand.CreationDate = DateTime.Now;
            await brandRepository.CreateAsync(brand);
        }
    }
}
