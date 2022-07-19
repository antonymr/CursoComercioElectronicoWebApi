using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IDeliveryMethodAppService
    {
        Task<ICollection<DeliveryMethodDto>> GetAllAsync();
        Task<DeliveryMethodDto> GetByIdAsync(string code);
        Task DeleteAsync(string Id);
        Task CreateAsync(CreateDeliveryMethodDto DeliveryMethodDto);
        Task UpdateAsync(string Id, CreateDeliveryMethodDto DeliveryMethodDto);
    }
}
