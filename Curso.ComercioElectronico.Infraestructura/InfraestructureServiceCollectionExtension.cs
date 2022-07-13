using Curso.ComercioElectronico.Dominio;
using Curso.ComercioElectronico.Dominio.Repositories;
using Curso.ComercioElectronico.Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Infraestructura
{
    public static class InfraestructureServiceCollectionExtension
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ComercioElectronicoDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("ComercioElectronico"));
            });
            services.AddTransient<ICatalogoRepositorio, CatalogoRepositorio>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IDeliveryMethodRepository, DeliveryMethodRepository>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
