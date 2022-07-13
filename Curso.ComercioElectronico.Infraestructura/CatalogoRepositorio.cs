using Curso.ComercioElectronico.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructura
{
    public class CatalogoRepositorio : ICatalogoRepositorio
    {
        private readonly ComercioElectronicoDbContext context;

        public CatalogoRepositorio(ComercioElectronicoDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Catalogo>> ObtenerAsync()
        {
            return await context.Catalogos.ToListAsync();
        }
    }
}