using Curso.ComercioElectronico.Aplicacion;
using Curso.ComercioElectronico.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase, ICatalogoAplicacion
    {
        private readonly ICatalogoAplicacion catalogoAplicacion;

        public CatalogoController(ICatalogoAplicacion catalogoAplicacion)
        {
            this.catalogoAplicacion = catalogoAplicacion;
        }

        [HttpGet]
        public Task<ICollection<Catalogo>> GetAsync()
        {
            return catalogoAplicacion.GetAsync();
        }
    }
}
