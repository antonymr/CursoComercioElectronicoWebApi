using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using Curso.ComercioElectronico.Aplicacion.Services;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderAppService
    {
        private readonly IOrderAppService orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            this.orderAppService = orderAppService;
        }

        [HttpGet]
        public Task<ResultPagination<OrderDto>> GetAllAsync(string? search = "", int offset = 0, int limit = 10, string sort = "Client", string order = "asc")
        {
            return orderAppService.GetAllAsync(search, offset, limit, sort, order);
        }

        [HttpGet("{id}")]
        public Task<OrderDto> GetByIdAsync(string id)
        {
            return orderAppService.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task UpdateAsync(Guid id, CreateOrderDto orderDto)
        {
            await orderAppService.UpdateAsync(id, orderDto);
        }

        [HttpPost]
        public async Task CreateAsync(CreateOrderDto orderDto)
        {
            await orderAppService.CreateAsync(orderDto);
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
             await orderAppService.DeleteAsync(id);
        }
    }
}
