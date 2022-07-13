using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class DeliveryMethodAppService : IDeliveryMethodAppService
    {
        private IDeliveryMethodRepository deliveryMethodRepository;

        public DeliveryMethodAppService(IDeliveryMethodRepository repository)
        {
            deliveryMethodRepository = repository;
        }

        public async Task<ICollection<DeliveryMethod>> GetAsync()
        {
            return await deliveryMethodRepository.GetAsync();
        }
    }
}
