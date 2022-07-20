using Curso.ComercioElectronico.Dominio.Repositories;
using Curso.ComercioElectronico.Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Curso.ComercioElectronico.Infraestructura
{
    public static class InfraestructureServiceCollectionExtension
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<EcommerceDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Ecommerce"));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
