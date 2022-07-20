using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using Curso.ComercioElectronico.Aplicacion.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase, IProductTypeAppService
    {
        private readonly IProductTypeAppService productTypeAppService;

        public ProductTypeController(IProductTypeAppService productTypeAppService)
        {
            this.productTypeAppService = productTypeAppService;
        }

        [HttpGet]
        public Task<ICollection<ProductTypeDto>> GetAllAsync()
        {
            return productTypeAppService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<ProductTypeDto> GetByIdAsync(string id)
        {
            return productTypeAppService.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task UpdateAsync(string code, CreateProductTypeDto productTypeDto)
        {
            await productTypeAppService.UpdateAsync(code, productTypeDto);
        }

        [HttpPost]
        public async Task CreateAsync(CreateProductTypeDto entity)
        {
            await productTypeAppService.CreateAsync(entity);
        }

        [HttpDelete]
        public async Task DeleteAsync(string code)
        {
            await productTypeAppService.DeleteAsync(code);
        }
    }
}
