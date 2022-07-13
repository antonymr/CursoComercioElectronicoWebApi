using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Infraestructura.Repositories
{
    public class DeliveryMethodRepository : IDeliveryMethodRepository
    {
        private readonly ComercioElectronicoDbContext context;

        public DeliveryMethodRepository(ComercioElectronicoDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<DeliveryMethod>> GetAsync()
        {
            var deliveryMethods = new List<DeliveryMethod>();
            return await Task.FromResult(deliveryMethods);
            //return await context.DeliveryMethods.ToListAsync();
        }
    }
}
