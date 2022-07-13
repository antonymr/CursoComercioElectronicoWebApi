using Curso.ComercioElectronico.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Infraestructura
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public Task<Cliente> ObtenerPorIdentificadorAsync(string identificador)
        {
            return Task.FromResult(new Cliente());
        }
    }
}
