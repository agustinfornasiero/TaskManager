using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManager.Application.DTOs;

namespace TaskManager.Application
{
    public static class ServiceCollectionExtensions
    { 
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(cfg => { cfg.AddProfile<MappingPofile>(); });

            return services;
        }
    }
}
