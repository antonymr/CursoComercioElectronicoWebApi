using Curso.ComercioElectronico.Dominio.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Dominio.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Listar todos los objetos de una entidad.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<T>> GetAsync();

        /// <summary>
        /// Obtener un objeto por su clave primaria en string. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(String id);

        /// <summary>
        /// Obtener un objeto de la base de datos por su clave primaria tipo Guid. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Crear un nuevo objeto en la base  de datos.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(T entity);

        /// <summary>
        /// Crear varios objetos en la base de datos
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task CreateRangeAsync(List<T> entities);

        /// <summary>
        /// Actualizar un objeto de la base de datos.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Eliminar un objeto de la base de datos.
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Devuelve una consulta sin ejecutar.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetQueryable();
    }
}
