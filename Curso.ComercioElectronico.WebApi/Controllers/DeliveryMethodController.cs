using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using Curso.ComercioElectronico.Aplicacion.Services;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryMethodController : ControllerBase, IDeliveryMethodAppService
    {
        private readonly IDeliveryMethodAppService deliveryMethodAppService;

        public DeliveryMethodController(IDeliveryMethodAppService DeliveryMethodAppService)
        {
            this.deliveryMethodAppService = DeliveryMethodAppService;
        }

        [HttpGet]
        public Task<ICollection<DeliveryMethodDto>> GetAllAsync()
        {
            return deliveryMethodAppService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<DeliveryMethodDto> GetByIdAsync(string id)
        {
            return deliveryMethodAppService.GetByIdAsync(id);
        }

        [HttpPut]
        public async Task UpdateAsync(string code, CreateDeliveryMethodDto DeliveryMethodDto)
        {
            await deliveryMethodAppService.UpdateAsync(code, DeliveryMethodDto);
        }

        [HttpPost]
        public async Task CreateAsync(CreateDeliveryMethodDto DeliveryMethodDto)
        {
            await deliveryMethodAppService.CreateAsync(DeliveryMethodDto);
        }

        [HttpDelete]
        public async Task DeleteAsync(string code)
        {
             await deliveryMethodAppService.DeleteAsync(code);
        }
    }
}
