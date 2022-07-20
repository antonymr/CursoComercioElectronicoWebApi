using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IOrderAppService
    {
        Task<ResultPagination<OrderDto>> GetAllAsync(string? search = "", int offset = 0, int limit = 10, string sort = "Client", string order = "asc");
        Task<OrderDto> GetByIdAsync(string code);
        Task DeleteAsync(Guid id);
        Task CreateAsync(CreateOrderDto orderDto);
        Task UpdateAsync(Guid id, CreateOrderDto orderDto);
    }
}
