using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IBrandAppService
    {
        Task<ICollection<BrandDto>> GetAllAsync();
        Task<BrandDto> GetByIdAsync(string code);
        Task DeleteAsync(string code);
        Task CreateAsync(CreateBrandDto brandDto);
        Task UpdateAsync(string code, CreateBrandDto brandDto);
    }
}
