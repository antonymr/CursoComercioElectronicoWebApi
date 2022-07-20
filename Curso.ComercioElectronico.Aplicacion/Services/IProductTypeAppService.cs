using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using Curso.ComercioElectronico.Dominio.Entities;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IProductTypeAppService
    {
        Task<ICollection<ProductTypeDto>> GetAllAsync();
        Task<ProductTypeDto> GetByIdAsync(string code);
        Task DeleteAsync(string code);
        Task CreateAsync(CreateProductTypeDto productTypeDto);
        Task UpdateAsync(string code, CreateProductTypeDto productTypeDto);
    }
}
