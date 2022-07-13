using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeliveryMethodController : ControllerBase, IDeliveryMethodAppService
    {
        private readonly IDeliveryMethodAppService deliveryMethodAppService;

        public DeliveryMethodController(IDeliveryMethodAppService deliveryMethodAppService)
        {
            this.deliveryMethodAppService = deliveryMethodAppService;
        }

        [HttpGet]
        public Task<ICollection<DeliveryMethod>> GetAsync()
        {
            return deliveryMethodAppService.GetAsync();
        }
    }
}
