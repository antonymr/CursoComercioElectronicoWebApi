using Curso.ComercioElectronico.Dominio;

namespace Curso.ComercioElectronico.Aplicacion
{
    public interface ICatalogoAplicacion
    {
        Task<ICollection<Catalogo>> GetAsync();
    }
}