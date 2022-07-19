using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using Curso.ComercioElectronico.Aplicacion.Services;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    //[Authorize]
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
        public async Task UpdateAsync(string code, CreateBrandDto brandDto)
        {
            await brandAppService.UpdateAsync(code, brandDto);
        }

        [HttpPost]
        public async Task CreateAsync(CreateBrandDto brandDto)
        {
            await brandAppService.CreateAsync(brandDto);
        }

        [HttpDelete]
        public async Task DeleteAsync(string code)
        {
             await brandAppService.DeleteAsync(code);
        }
    }
}
