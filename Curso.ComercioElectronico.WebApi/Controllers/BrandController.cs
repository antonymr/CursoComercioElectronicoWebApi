using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase, IBrandAppService
    {
        private readonly IBrandAppService brandAppService;

        public BrandController(IBrandAppService brandAppService)
        {
            this.brandAppService = brandAppService;
        }


        [HttpGet]
        public Task<ICollection<BrandDto>> GetAllAsync()
        {
            return brandAppService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<BrandDto> GetByIdAsync(string id)
        {
            return brandAppService.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task UpdateAsync(CreateBrandDto entity)
        {
            await brandAppService.UpdateAsync(entity);
        }

        [HttpPost]
        public async Task CreateAsync(CreateBrandDto brandDto)
        {
            await brandAppService.CreateAsync(brandDto);
        }

        [HttpDelete]
        public Task<bool> DeleteAsync(Brand entity)
        {
            return brandAppService.DeleteAsync(entity);
        }
    }
}
