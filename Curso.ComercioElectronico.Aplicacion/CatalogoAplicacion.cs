using Curso.ComercioElectronico.Dominio;
using Curso.ComercioElectronico.Infraestructura;

namespace Curso.ComercioElectronico.Aplicacion
{
    public class CatalogoAplicacion : ICatalogoAplicacion
    {
        private ICatalogoRepositorio CatalogoRepositorio { get; set; }

        public CatalogoAplicacion(ICatalogoRepositorio repositorio)
        {
            CatalogoRepositorio = repositorio;
        }
        public Task<ICollection<Catalogo>> GetAsync()
        {
            return CatalogoRepositorio.ObtenerAsync();
        }
    }
}