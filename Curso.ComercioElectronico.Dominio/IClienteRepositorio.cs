namespace Curso.ComercioElectronico.Dominio
{
    public interface IClienteRepositorio
    {
        Task<Cliente> ObtenerPorIdentificadorAsync(string identificador);
    }
}