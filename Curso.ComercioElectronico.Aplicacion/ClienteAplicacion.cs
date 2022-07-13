using Curso.ComercioElectronico.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion
{
    public class ClienteAplicacion : IClienteAplicacion
    {
        private IClienteRepositorio ClienteRepositorio { get; set; }

        public ClienteAplicacion(IClienteRepositorio clienteRepositorio)
        {
            ClienteRepositorio = clienteRepositorio;
        }

        public async Task<Cliente> ObtenerPorIdentificadorAsync(string identificador)
        {
            return await ClienteRepositorio.ObtenerPorIdentificadorAsync(identificador);
        }
    }
}
