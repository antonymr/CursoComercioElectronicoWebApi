using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using Curso.ComercioElectronico.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IProductAppService
    {
        Task<ResultPagination<ProductDto>> GetAllAsync(string? search = "", int offset = 0, int limit = 10, string sort = "Name", string order = "asc");
        Task<ProductDto> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task CreateAsync(CreateProductDto productTypeDto);
        Task UpdateAsync(Guid id, CreateProductDto productTypeDto);
    }

    public class ResultPagination<T>
    {
        public int Total { get; set; }
        public ICollection<T> Items { get; set; }
    }
}
