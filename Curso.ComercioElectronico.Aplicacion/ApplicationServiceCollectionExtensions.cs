using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Aplicacion.ServicesImpl;
using Curso.ComercioElectronico.Aplicacion.Validator;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplicacion
{
    public  static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IProductAppService, ProductAppService>();
            services.AddTransient<IProductTypeAppService, ProductTypeAppService>();
            services.AddTransient<IBrandAppService, BrandAppService>();
            services.AddTransient<IDeliveryMethodAppService, DeliveryMethodAppService>();
            services.AddTransient<IOrderAppService, OrderAppService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
