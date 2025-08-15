
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManager.Application.DTOs;

namespace TaskManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra MediatR para el procesamiento de comandos y consultas
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Configura AutoMapper manualmente
            services.AddSingleton<IMapper>(provider =>
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfile());
                });
                return configuration.CreateMapper();
            });

            return services;
        }
    }
}

