using Curso.ComercioElectronico.Dominio.Entities;

namespace Curso.ComercioElectronico.Dominio.Repositories
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAsync();
    }
}
