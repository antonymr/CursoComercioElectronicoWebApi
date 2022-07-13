using Curso.ComercioElectronico.Dominio;

namespace Curso.ComercioElectronico.Dominio
{
    public interface ICatalogoRepositorio
    {
        Task<ICollection<Catalogo>> ObtenerAsync();
    }
}