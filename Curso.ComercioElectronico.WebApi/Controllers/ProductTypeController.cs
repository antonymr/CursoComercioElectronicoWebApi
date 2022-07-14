using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    [Authorize]
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
        public Task<ProductTypeDto> UpdateAsync(ProductType entity)
        {
            return productTypeAppService.UpdateAsync(entity);
        }

        [HttpPost]
        public async Task CreateAsync(CreateProductTypeDto entity)
        {
            await productTypeAppService.CreateAsync(entity);
        }

        [HttpDelete]
        public Task<bool> DeleteAsync(ProductType entity)
        {
            return productTypeAppService.DeleteAsync(entity);
        }
    }
}
