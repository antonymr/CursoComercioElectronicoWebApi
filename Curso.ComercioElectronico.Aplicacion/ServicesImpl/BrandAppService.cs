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
    public class BrandAppService : IBrandAppService
    {
        private readonly IGenericRepository<Brand> brandRepository;
        private readonly IValidator<CreateBrandDto> validator;

        public BrandAppService(IGenericRepository<Brand> repository, IValidator<CreateBrandDto> validator)
        {
            brandRepository = repository;
            this.validator = validator;
        }

        public async Task<ICollection<BrandDto>> GetAllAsync()
        {
            var query = await brandRepository.GetAsync();
            var result = query.Select(x => new BrandDto
            {
                Code = x.Code,
                Description = x.Description,
                CreationDate = x.CreationDate
            });
            return result.ToList();
        }

        public async Task<BrandDto> GetByIdAsync(string code)
        {
            var query = brandRepository.GetQueryable();
            query = query.Where(x => x.Code == code);
            var resultQuery = query.Select(x => new BrandDto
            {
                Code = x.Code,
                Description = x.Description,
                CreationDate = x.CreationDate
            });
            return await resultQuery.SingleOrDefaultAsync();
        }

        public async Task<bool> DeleteAsync(Brand entity)
        {
            await brandRepository.DeleteAsync(entity);
            return true;
        }

        public async Task UpdateAsync(CreateBrandDto brandDto)
        {
            Brand brand = new Brand();
            brand.Code = brandDto.Code;
            brand.Description = brandDto.Description;
            brand.ModifiedDate = DateTime.Now;
            await brandRepository.UpdateAsync(brand);
        }

        public async Task CreateAsync(CreateBrandDto brandDto)
        {
            Brand brand = new Brand();
            brand.Code = brandDto.Code;
            brand.Description = brandDto.Description;
            brand.CreationDate = DateTime.Now;
            await brandRepository.CreateAsync(brand);
        }
    }
}
