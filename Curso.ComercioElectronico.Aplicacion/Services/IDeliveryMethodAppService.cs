using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;

namespace Curso.ComercioElectronico.Aplicacion.Services
{
    public interface IDeliveryMethodAppService
    {
        Task<ICollection<DeliveryMethodDto>> GetAllAsync();
        Task<DeliveryMethodDto> GetByIdAsync(string code);
        Task DeleteAsync(string code);
        Task CreateAsync(CreateDeliveryMethodDto deliveryMethodDto);
        Task UpdateAsync(string code, CreateDeliveryMethodDto deliveryMethodDto);
    }
}
