using Curso.ComercioElectronico.Dominio;

namespace Curso.ComercioElectronico.Aplicacion
{
    public interface IClienteAplicacion
    {
        Task<Cliente> ObtenerPorIdentificadorAsync(string identificador);
    }
}