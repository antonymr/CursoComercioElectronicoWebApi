using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductAppService
    {
        private readonly IProductAppService productAplicacion;

        public ProductController(IProductAppService productAplicacion)
        {
            this.productAplicacion = productAplicacion;
        }

        [HttpGet]
        public async Task<ResultPagination<ProductDto>> GetAllAsync(string? search = "", int offset = 0, int limit = 10, string sort = "Name", string order = "asc")
        {
            return await productAplicacion.GetAllAsync(search, offset, limit, sort, order);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            return await productAplicacion.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task UpdateAsync(Guid id, CreateProductDto entity)
        {
            await productAplicacion.UpdateAsync(id, entity);
        }

        [HttpPost]
        public async Task CreateAsync(CreateProductDto entity)
        {
            await productAplicacion.CreateAsync(entity);
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await productAplicacion.DeleteAsync(id);
        }
    }
}
